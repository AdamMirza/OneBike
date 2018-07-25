using BikeHack.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Threading.Tasks;

namespace BikeHack
{
    public class TripStorage
    {
        private const string TableName = "trips";
        private CloudTable _table;

        public TripStorage(CloudStorageAccount account)
        {
            var client = account.CreateCloudTableClient();
            _table = client.GetTableReference(TableName);
        }

        public async Task InsertTripAsync(Trip trip)
        {
            //TODO insert trip into table
        }

        public async Task<Trip> RetrieveTripAsync(Guid tripId)
        {
            return null;
        }

        public async Task UpdateTripAsync(Trip trip)
        {

        }
    }
}
