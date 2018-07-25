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
        private BikeStorage _bikeStorage;
        private TripStorage _tripStorage;

        public TripsController(BikeStorage bikeStorage, TripStorage tripStorage)
        {
            _bikeStorage = bikeStorage;
            _tripStorage = tripStorage;
            Utility.LogMessage("Started trips controller successfully.");
        }

        [HttpPost]
        public async Task<IActionResult> StartTrip([FromBody] Trip trip)
        {
            trip.TripId = Guid.NewGuid();
            trip.StartTime = DateTimeOffset.UtcNow;
            if (trip.BikeId == null || trip.StartLatitude == null || trip.StartLongitude == null)
            {
                return BadRequest();
            }
            trip.EndLatitude = trip.StartLatitude;
            trip.EndLongitude = trip.StartLongitude;
            var bike = await _bikeStorage.RetrieveBikeAsync(trip.BikeId.Value);
            if (bike.State == BikeState.Active)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed, "The associated bike is already on a trip.");
            }
            bike.CurrentTripId = trip.TripId;
            bike.State = BikeState.Active;
            await _tripStorage.InsertTripAsync(trip);
            await _bikeStorage.UpdateBikeAsync(bike);
            //TODO make sure user is registered (stretch)
            return Ok();
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
                return StatusCode((int)HttpStatusCode.PreconditionFailed, "The trip ID provided corresponds to an already completed trip.");
            }
            trip.EndTime = DateTimeOffset.UtcNow;
            trip.UpdateLocation(endLatitude, endLongitude);
            var bike = await _bikeStorage.RetrieveBikeAsync(trip.BikeId.Value);
            bike.MilesTraveled += trip.TripMiles;
            //TODO (stretch) add trip to bike history
            return Ok();
        }
    }
}
