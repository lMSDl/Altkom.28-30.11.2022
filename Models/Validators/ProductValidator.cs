using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validators
{
    internal class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() { 
            
            RuleFor(x => x.Name).MinimumLength(5).NotEmpty().NotNull().WithName("Nazwa");
            RuleFor(x => x.ExpirationDate).GreaterThan(DateTime.Now);
        }
    }
}
