using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BikeHack.Models;

namespace BikeHack.Controllers
{
    [Route("bikes")]
    public class BikesController : Controller
    {
        private BikeStorage _bikeStorage;
        private TripStorage _tripStorage;

        public BikesController(BikeStorage bikeStorage, TripStorage tripStorage)
        {
            _bikeStorage = bikeStorage;
            _tripStorage = tripStorage;
            Utility.LogMessage("Started bikes controller successfully.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBike([FromBody] BikeStatus status)
        {
            Utility.LogMessage("CreateBike request.");
            var bike = new Bike(status);
            await _bikeStorage.InsertBikeAsync(bike);
            return CreatedAtAction(nameof(GetStatus), new { bikeId = bike.BikeId }, bike);
        }

        [HttpGet]
        public async Task<IActionResult> GetBikeIds([FromQuery] string state)
        {
            BikeState? bikeState = state != null ? new BikeState?(Enum.Parse<BikeState>(state, true)) : null;
            var bikes = await _bikeStorage.GetBikesAsync(bikeState);
            var bikeIds = bikes.Select(bike => bike.BikeId);
            return Ok(bikeIds);
        }

        [HttpPatch("{bikeId}")]
        public async Task<IActionResult> UpdateBikeStatus([FromRoute] Guid bikeId, [FromBody] BikeStatus status)
        {
            var bike = await _bikeStorage.RetrieveBikeAsync(bikeId);
            bike.UpdateStatus(status);
            if (bike.State ==  BikeState.Active)
            {
                var trip = await _tripStorage.RetrieveTripAsync(bike.CurrentTripId.Value);
                trip.UpdateLocation(bike.Latitude, bike.Longitude);
                await _tripStorage.UpdateTripAsync(trip);
            }
            await _bikeStorage.UpdateBikeAsync(bike);
            return Ok();
        }

        [HttpGet("{bikeId}")]
        public async Task<IActionResult> GetStatus([FromRoute] Guid bikeId)
        {
            var bike = await _bikeStorage.RetrieveBikeAsync(bikeId);
            return Ok(bike);
        }
    }
}
