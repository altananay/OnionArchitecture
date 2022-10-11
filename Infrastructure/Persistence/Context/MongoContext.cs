using Domain.Entities.Common;
using MongoDB.Driver;
using Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class MongoContext : IMongoContext
    {
        public MongoClient connection { get; }

        public IMongoDatabase database { get; set; }


        public MongoContext()
        {
            this.connection = new MongoClient(Configuration.ConnectionString);
            this.database = this.connection.GetDatabase("test");
        }
    }
}