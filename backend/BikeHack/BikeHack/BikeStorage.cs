using BikeHack.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeHack
{
    public class BikeStorage
    {
        private const string TableName = "bikes";
        private CloudTable _bikeTable;

        public BikeStorage(CloudStorageAccount account)
        {
            var client = account.CreateCloudTableClient();
            _bikeTable = client.GetTableReference(TableName);
        }

        public async Task InitializeAsync()
        {
            await _bikeTable.CreateIfNotExistsAsync();
        }

        public async Task UpdateBikeStatusAsync(Guid bikeId, BikeStatus status)
        {
            var bike = await RetrieveBikeAsync(bikeId) ?? new Bike(status, bikeId);
            var operation = TableOperation.InsertOrReplace(bike);
            await _bikeTable.ExecuteAsync(operation);
        }

        public async Task<Bike> RetrieveBikeAsync(Guid bikeId)
        {
            var retrieveOperation = TableOperation.Retrieve<Bike>(Guid.Empty.ToString(), bikeId.ToString());
            var result = await _bikeTable.ExecuteAsync(retrieveOperation);
            return result.Result as Bike;
        }
    }
}
