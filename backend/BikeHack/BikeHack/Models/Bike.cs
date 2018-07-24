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

        public Bike(BikeStatus status, Guid bikeId) : this()
        {
            UpdateStatus(status);
            BikeId = bikeId;
        }

        public BikeStatus GetStatus()
        {
            return new BikeStatus
            {
                Latitude = Latitude,
                Longitude = Longitude,
                BatteryPercentage = BatteryPercentage
            };
        }

        public void UpdateStatus(BikeStatus status)
        {
            Latitude = status.Latitude;
            Longitude = status.Longitude;
            BatteryPercentage = status.BatteryPercentage;
        }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int BatteryPercentage { get; set; }

        public BikeState State { get; set; }

        [IgnoreProperty]
        public Guid BikeId
        {
            get => Guid.Parse(RowKey);
            set
            {
                RowKey = value.ToString();
            }
        }

        public string BikeState
        {
            get
            {
                return State.ToString();
            }

            set
            {
                State = Enum.Parse<BikeState>(value);
            }
        }

        public Guid? CurrentTripId { get; set; }

        public string TripHistory { get; set; }

        public double MilesTraveled { get; set; }

        public DateTimeOffset DeploymentTime { get; set; }
    }
}
