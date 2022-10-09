using Domain.Entities;
using Domain.Entities.Common;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IReadRepository<Entity> : IRepository<Entity> where Entity : BaseEntity
    {
        Entity GetById(string id);
        IQueryable<Entity> GetAll();
        Entity Get(Expression<Func<Entity, bool>> filter);
    }
}