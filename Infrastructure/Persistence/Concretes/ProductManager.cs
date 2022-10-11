using Application.Abstractions;
using Application.Aspects;
using Application.Constants;
using Application.Repositories;
using Application.Results;
using Application.Validators;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Concretes
{
    public class ProductManager : IProductService
    {
        IProductWriteRepository _productWriteRepository;

        public ProductManager(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }


        [ValidationAspect(typeof(ProductValidator))]
        [SecuredOperation("admin,product.add")]
        public IResult Add(Product product)
        {
            _productWriteRepository.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
    }
}