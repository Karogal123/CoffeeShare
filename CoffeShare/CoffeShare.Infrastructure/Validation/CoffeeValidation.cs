using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;
using FluentValidation;

namespace CoffeeShare.Infrastructure.Validation
{
    public class CoffeeValidation : AbstractValidator<CoffeeDto>
    {
        public CoffeeValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);
            RuleFor(x => x.ManufacturerId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Manufacturer can not be empty");
            RuleFor(x => x.CountryId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Country can not be empty");
            RuleFor(x => x.BeanType)
                .IsInEnum()
                .WithMessage("Wrong bean type");
            RuleFor(x => x.BeansProcessing)
                .IsInEnum()
                .WithMessage("Wrong bean processing");
            RuleFor(x => x.DegreeOfRoasting)
                .IsInEnum()
                .WithMessage("Wrong degree of roasting");
        }
    }
}
