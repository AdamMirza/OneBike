using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BikeHack.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace BikeHack.Controllers
{
    [Route("bikes")]
    public class BikesController : Controller
    {
        private BikeStorage _bikeStorage;

        public BikesController(CloudStorageAccount storageAccount)
        {
            _bikeStorage = new BikeStorage(storageAccount);
        }

        [HttpPost("{bikeId}/status")]
        public async Task<IActionResult> PostStatus([FromRoute] Guid bikeId, [FromBody] BikeStatus status)
        {
            //TODO add to trip distance if bike is on a trip
            await _bikeStorage.UpdateBikeStatusAsync(bikeId, status);
            return Ok();
        }

        [HttpGet("{bikeId}/status")]
        public async Task<IActionResult> GetStatus([FromRoute] Guid bikeId)
        {
            var bike = await _bikeStorage.RetrieveBikeAsync(bikeId);
            return Ok(bike.GetStatus());
        }

        [HttpPost("{bikeId}/startTrip")]
        public IActionResult StartTrip([FromRoute] Guid bikeId)
        {
            return Ok();
        }

        [HttpPost("{bikeId}/endTrip")]
        public IActionResult EndTrip([FromRoute] Guid bikeId)
        {
            return Ok();
        }
       
        [HttpGet]
        public IActionResult GetAllBikeIds([FromQuery] string state)
        {
            return Ok();
        }
    }
}
