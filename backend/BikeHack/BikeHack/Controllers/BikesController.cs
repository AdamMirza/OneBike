using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BikeHack.Models;
using Microsoft.WindowsAzure.Storage;

namespace BikeHack.Controllers
{
    [Route("bikes")]
    public class BikesController : Controller
    {
        private BikeStorage _bikeStorage;

        public BikesController(CloudStorageAccount storageAccount)
        {
            _bikeStorage = new BikeStorage(storageAccount);
            Utility.LogMessage("Started bikes controller successfully.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBike([FromBody] BikeStatus status)
        {
            Utility.LogMessage("CreateBike request.");
            var bike = await _bikeStorage.CreateBikeAsync(status);
            return CreatedAtAction(nameof(GetStatus), new { bikeId = bike.BikeId }, bike);
        }

        [HttpGet]
        public async Task<IActionResult> GetBikeIds([FromQuery] string state)
        {
            BikeState? bikeState = state != null ? new BikeState?(Enum.Parse<BikeState>(state)) : null;
            var bikes = await _bikeStorage.GetBikesAsync(bikeState);
            var bikeIds = bikes.Select(bike => bike.BikeId);
            return Ok(bikeIds);
        }

        [HttpPatch("{bikeId}")]
        public async Task<IActionResult> UpdateBikeStatus([FromRoute] Guid bikeId, [FromBody] BikeStatus status)
        {
            //TODO add to trip distance if bike is on a trip
            await _bikeStorage.UpdateBikeStatusAsync(bikeId, status);
            return Ok();
        }

        [HttpGet("{bikeId}")]
        public async Task<IActionResult> GetStatus([FromRoute] Guid bikeId)
        {
            var bike = await _bikeStorage.RetrieveBikeAsync(bikeId);
            return Ok(bike.GetStatus());
        }
    }
}
