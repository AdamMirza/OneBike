using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BikeHack.Models;
using System.Net;

namespace BikeHack.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        private readonly BikeStorage _bikeStorage;
        private readonly TripStorage _tripStorage;
        private readonly UserStorage _userStorage;

        public UserController(BikeStorage bikeStorage, TripStorage tripStorage, UserStorage userStorage)
        {
            _bikeStorage = bikeStorage;
            _tripStorage = tripStorage;
            _userStorage = userStorage;
            Utility.LogMessage("Started user controller successfully.");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            var existingUser = await _userStorage.RetrieveUserAsync(user.UserId);
            if (existingUser != null)
            {
                return StatusCode((int)HttpStatusCode.Conflict, new { message = "A user already exists with the given id." });
            }
            await _userStorage.InsertUserAsync(user);
            return Ok();
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser([FromRoute] string userId)
        {
            var user = await _userStorage.RetrieveUserAsync(userId);
            return user == null ? (IActionResult)NotFound() : Ok(user);
        }
    }
}
