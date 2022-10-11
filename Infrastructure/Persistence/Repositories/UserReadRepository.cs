using Application.Repositories;
using Application.Results;
using Domain.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(IMongoContext mongoContext) : base(mongoContext, "users")
        {
        }

        //public Task<OperationClaim> GetClaims(string id)
        //{
        //    var result = collection.Find(x => x._id == id).Project(x => new OperationClaim { _id = x._id, Name = x.Claim }).FirstAsync();
        //    return result;
        //}
    }
}