using Application.Repositories;
using Application.Results;
using Domain.Entities;
using MongoDB.Driver;
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
    }
}