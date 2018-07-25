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
    }
}
