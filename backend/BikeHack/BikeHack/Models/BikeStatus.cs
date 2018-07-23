using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeHack.Models
{
    public class BikeStatus
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int BatteryPercentage { get; set; }
    }
}
