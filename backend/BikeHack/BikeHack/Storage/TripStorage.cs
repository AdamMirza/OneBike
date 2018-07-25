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
            var operation = TableOperation.Insert(trip);
            await _table.ExecuteAsync(operation);
        }

        public async Task<Trip> RetrieveTripAsync(Guid tripId)
        {
            var retrieveOperation = TableOperation.Retrieve<Trip>(Guid.Empty.ToString(), tripId.ToString());
            var result = await _table.ExecuteAsync(retrieveOperation);
            return result.Result as Trip;
        }

        public async Task UpdateTripAsync(Trip trip)
        {
            var operation = TableOperation.Replace(trip);
            await _table.ExecuteAsync(operation);
        }
    }
}
