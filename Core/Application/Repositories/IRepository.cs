using Domain.Entities.Common;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRepository<Entity> where Entity : BaseEntity
    {
        IMongoCollection<Entity> collection { get; }
    }
}