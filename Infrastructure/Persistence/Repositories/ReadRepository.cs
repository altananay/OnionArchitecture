using Application.Repositories;
using Domain.Entities.Common;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistence.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ReadRepository<Entity> : IReadRepository<Entity> where Entity : BaseEntity
    {
        private readonly IMongoContext _mongoContext;
        private readonly string _collection;

        public ReadRepository(IMongoContext mongoContext, string collection)
        {
            _mongoContext = mongoContext;
            _collection = collection;
        }

        public IMongoCollection<Entity> collection => _mongoContext.database.GetCollection<Entity>(_collection);

        public Entity Get(Expression<Func<Entity, bool>> filter)
        {
            return collection.AsQueryable().SingleOrDefault(filter);
        }

        public IQueryable<Entity> GetAll()
        {
            var results = collection.AsQueryable();
            return results;
        }

        public Entity GetById(string id)
        {
            //6329eef52e1e7451846af943
            var result = collection.AsQueryable().Where(x => x._id == id.ToString()).FirstOrDefault();
            return result;
        }
    }
}
