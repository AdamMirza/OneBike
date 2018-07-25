using BikeHack.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Threading.Tasks;

namespace BikeHack
{
    public class UserStorage
    {
        private const string TableName = "users";
        private CloudTable _table;

        public UserStorage(CloudStorageAccount account)
        {
            var client = account.CreateCloudTableClient();
            _table = client.GetTableReference(TableName);
        }

        public async Task InsertUserAsync(User user)
        {
            var operation = TableOperation.Insert(user);
            await _table.ExecuteAsync(operation);
        }

        public async Task<User> RetrieveUserAsync(string userId)
        {
            var retrieveOperation = TableOperation.Retrieve<User>(Guid.Empty.ToString(), userId);
            var result = await _table.ExecuteAsync(retrieveOperation);
            return result.Result as User;
        }

        public async Task UpdateUserAsync(User user)
        {
            var operation = TableOperation.Replace(user);
            await _table.ExecuteAsync(operation);
        }
    }
}
