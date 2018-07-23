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
            return Ok();
        }

        [HttpGet("{bikeId}/status")]
        public IActionResult GetStatus([FromRoute] string bikeId)
        {
            return Ok();
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
