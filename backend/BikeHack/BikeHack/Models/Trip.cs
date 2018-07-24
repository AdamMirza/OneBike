using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeHack.Models
{
    public class Trip : TableEntity
    {
        public Trip()
        {
        }

        DateTimeOffset StartTime { get; set; }

        DateTimeOffset? EndTime { get; set; }

        [IgnoreProperty]
        public Guid TripId
        {
            get => Guid.Parse(RowKey);
            set
            {
                RowKey = value.ToString();
            }
        }

        public double StartLongitude { get; set; }

        public double StartLatitude { get; set; }

        public double EndLongitude { get; set; }

        public double EndLatitude { get; set; }

        public Guid BikeId { get; set; }

        public Guid UserId { get; set; }

        public double TripMiles { get; set; }
    }
}
