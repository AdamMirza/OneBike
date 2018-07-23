using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BikeHack.Models;

namespace BikeHack.Controllers
{
    [Route("bikes")]
    public class BikesController : Controller
    {
        [HttpPost("{bikeId}/status")]
        public IActionResult PostStatus([FromRoute] string bikeId)
        {
            // TODO update bike status
            return Ok();
        }

        [HttpGet("{bikeId}/status")]
        public IActionResult GetStatus([FromRoute] string bikeId)
        {
            // TODO get actual bike status
            return Ok(new BikeStatus { BatteryPercentage = 99, Latitude = 4, Longitude = 5 });
        }

        [HttpPost("{bikeId}/checkout")]
        public IActionResult CheckOut([FromRoute] string bikeId)
        {
            return Ok();
        }

        [HttpPost("{bikeId}/checkin")]
        public IActionResult CheckIn([FromRoute] string bikeId)
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
