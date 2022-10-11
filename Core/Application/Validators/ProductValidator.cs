using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.productName).NotEmpty().MinimumLength(5);
            RuleFor(p => p.unitPrice).NotEmpty().GreaterThan(0);
            RuleFor(p => p.unitsInStock).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}