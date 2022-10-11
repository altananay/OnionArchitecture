using Application.Repositories;
using Domain.Entities;
using MongoDB.Bson;
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
    public class UserClaimReadRepository : ReadRepository<UserOperationClaim>, IUserClaimReadRepository
    {
        public UserClaimReadRepository(IMongoContext mongoContext) : base(mongoContext, "userclaims")
        {
        }

        //public string GetClaims(string id)
        //{
        //    //var result = collection.AsQueryable().Where(x => x.UserId == id);
        //    var result = collection.Find(x => true).Project(x => new OperationClaim { Name = x.UserClaims });
        //    return result;
        //}
    }
}