using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeHack.Models
{
    public enum BikeState
    {
        Active, Idle
    }

    public class Bike : TableEntity
    {
        public Bike()
        {
            PartitionKey = Guid.Empty.ToString();
        }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int BatteryPercentage { get; set; }

        public BikeState? State { get; set; }

        [IgnoreProperty]
        public Guid? BikeId
        {
            get => RowKey != null ? new Guid?(Guid.Parse(RowKey)) : null;
            set
            {
                RowKey = value.ToString();
            }
        }

        public void UpdateLocation(double latitude, double longitude)
        {
            MilesTraveled += Utility.MilesBetweenCoordinates(Latitude, Longitude, latitude, longitude);
            Latitude = latitude;
            Longitude = longitude;
        }

        public string BikeState
        {
            get
            {
                return State.ToString();
            }

            set
            {
                State = Enum.Parse<BikeState>(value, true);
            }
        }

        public Guid? CurrentTripId { get; set; }

        public string TripHistory { get; set; }

        public double MilesTraveled { get; set; }

        public DateTimeOffset? DeploymentTime { get; set; }
    }
}
