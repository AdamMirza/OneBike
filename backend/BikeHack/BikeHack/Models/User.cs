using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeHack.Models
{
    public class User : TableEntity
    {
        public User()
        {
            PartitionKey = Guid.Empty.ToString();
        }

        public string UserId
        {
            get => RowKey;
            set
            {
                RowKey = value;
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TripHistory { get; set; }

        public string ProfileImageUrl { get; set; }
    }
}
