using BikeHack.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeHack
{
    public class BikeStorage
    {
        private const string TableName = "bikes";
        private const string StatePropertyName = "BikeState";
        private const string PartitionKeyPropertyName = "PartitionKey";
        private CloudTable _table;

        public BikeStorage(CloudStorageAccount account)
        {
            var client = account.CreateCloudTableClient();
            _table = client.GetTableReference(TableName);
        }

        public async Task<Bike> CreateBikeAsync(BikeStatus status)
        {
            var bikeId = Guid.NewGuid();
            var bike = new Bike(status, bikeId);
            var operation = TableOperation.Insert(bike);
            await _table.ExecuteAsync(operation);
            return bike;
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

        public async Task<IEnumerable<Bike>> GetBikesAsync(BikeState? state)
        {
            TableQuery<Bike> query = new TableQuery<Bike>
            {
                FilterString = TableQuery.GenerateFilterCondition(PartitionKeyPropertyName, QueryComparisons.Equal, Guid.Empty.ToString())
            };
            if (state.HasValue)
            {
                var stateFilter = TableQuery.GenerateFilterCondition(StatePropertyName, QueryComparisons.Equal, state.Value.ToString());
                query.FilterString = TableQuery.CombineFilters(query.FilterString, TableOperators.And, stateFilter);
            }

            TableContinuationToken token = null;
            var bikes = new List<Bike>();
            do
            {
                var querySegment = await _table.ExecuteQuerySegmentedAsync(query, token);
                token = querySegment.ContinuationToken;
                bikes.AddRange(querySegment.Results);
            } while (token != null);
            return bikes;
        }
    }
}
