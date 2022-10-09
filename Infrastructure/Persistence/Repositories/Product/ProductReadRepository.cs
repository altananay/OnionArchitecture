using Application.Repositories;
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
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(IMongoContext mongoContext) : base(mongoContext, "products")
        {

        }
    }
}