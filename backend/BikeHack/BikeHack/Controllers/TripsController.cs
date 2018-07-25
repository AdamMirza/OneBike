using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BikeHack.Models;
using System.Net;

namespace BikeHack.Controllers
{
    [Route("trips")]
    public class TripsController : Controller
    {
        private readonly BikeStorage _bikeStorage;
        private readonly TripStorage _tripStorage;
        private readonly UserStorage _userStorage;

        public TripsController(BikeStorage bikeStorage, TripStorage tripStorage, UserStorage userStorage)
        {
            _bikeStorage = bikeStorage;
            _tripStorage = tripStorage;
            _userStorage = userStorage;
            Utility.LogMessage("Started trips controller successfully.");
        }

        [HttpPost]
        public async Task<IActionResult> StartTrip([FromBody] Trip trip)
        {
            if (trip.BikeId == null || trip.StartLatitude == null || trip.StartLongitude == null)
            {
                return BadRequest();
            }
            var bike = await _bikeStorage.RetrieveBikeAsync(Guid.Parse(trip.BikeId));
            if (bike == null)
            {
                return NotFound(new { message = "Could not find a bike for the given id" });
            }
            if (bike.State == BikeState.Active)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed, new { message = "The associated bike is already on a trip." });
            }
            var user = await _userStorage.RetrieveUserAsync(trip.UserId);
            if (user == null)
            {
                return NotFound(new { message = "Could not find a user for the given id" });
            }
            trip.EndLatitude = trip.StartLatitude;
            trip.EndLongitude = trip.StartLongitude;
            trip.TripId = Guid.NewGuid();
            trip.TripMiles = 0;
            trip.StartTime = DateTimeOffset.UtcNow;

            bike.CurrentTripId = trip.TripId;
            bike.State = BikeState.Active;
            bike.UpdateLocation(trip.StartLatitude.Value, trip.StartLongitude.Value);
            await _tripStorage.InsertTripAsync(trip);
            await _bikeStorage.UpdateBikeAsync(bike);
            return Ok(trip.TripId);
        }

        [HttpPatch("{tripId}")]
        public async Task<IActionResult> EndTrip([FromRoute] Guid tripId, [FromBody] double endLatitude, [FromBody] double endLongitude)
        {
            var trip = await _tripStorage.RetrieveTripAsync(tripId);
            if (trip == null)
            {
                return NotFound("Could not find a trip with the given ID");
            }
            if (trip.EndTime != null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed, new { message = "The trip ID provided corresponds to an already completed trip." });
            }
            trip.EndTime = DateTimeOffset.UtcNow;
            trip.UpdateLocation(endLatitude, endLongitude);
            var bike = await _bikeStorage.RetrieveBikeAsync(Guid.Parse(trip.BikeId));
            bike.UpdateLocation(endLatitude, endLongitude);
            bike.TripHistory += tripId.ToString() + ";";
            await _bikeStorage.UpdateBikeAsync(bike);
            var user = await _userStorage.RetrieveUserAsync(trip.UserId);
            user.TripHistory += tripId.ToString() + ";";
            await _userStorage.UpdateUserAsync(user);
            return Ok();
        }
    }
}
