using Application.Aspects;
using Application.Repositories;
using Domain.Entities.Common;
using MongoDB.Driver;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly IMongoContext _mongoContext;
        private readonly string _collection;

        public WriteRepository(IMongoContext mongoContext, string collection)
        {
            _mongoContext = mongoContext;
            _collection = collection;
        }

        public IMongoCollection<T> collection => _mongoContext.database.GetCollection<T>(_collection);

        [SecuredOperation("admin,product.add")]
        public async Task<bool> Add(T entity)
        {
            await collection.InsertOneAsync(entity);
            return true;
        }

        public async Task<bool> Delete(string id)
        {
            await collection.DeleteOneAsync(t => t._id == id);
            return true;
        }
    }
}
