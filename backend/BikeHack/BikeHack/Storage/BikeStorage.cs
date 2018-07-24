using BikeHack.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Threading.Tasks;

namespace BikeHack
{
    public class BikeStorage
    {
        private const string TableName = "bikes";
        private CloudTable _table;

        public BikeStorage(CloudStorageAccount account)
        {
            var client = account.CreateCloudTableClient();
            _table = client.GetTableReference(TableName);
        }

        public async Task UpdateBikeStatusAsync(Guid bikeId, BikeStatus status)
        {
            var bike = await RetrieveBikeAsync(bikeId) ?? new Bike(status, bikeId);
            var operation = TableOperation.InsertOrReplace(bike);
            await _table.ExecuteAsync(operation);
        }

        public async Task<Bike> RetrieveBikeAsync(Guid bikeId)
        {
            var retrieveOperation = TableOperation.Retrieve<Bike>(Guid.Empty.ToString(), bikeId.ToString());
            var result = await _table.ExecuteAsync(retrieveOperation);
            return result.Result as Bike;
        }
    }
}
