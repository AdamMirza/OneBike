﻿using Microsoft.WindowsAzure.Storage.Table;
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
            PartitionKey = Guid.Empty.ToString();
        }

        DateTimeOffset StartTime { get; set; }

        DateTimeOffset? EndTime { get; set; }

        [IgnoreProperty]
        public Guid? TripId
        {
            get => RowKey != null ? new Guid?(Guid.Parse(RowKey)) : null;
            set
            {
                RowKey = value.ToString();
            }
        }

        public void UpdateLocation(double latitude, double longitude)
        {

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
