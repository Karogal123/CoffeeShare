using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;
using FluentValidation;

namespace CoffeeShare.Infrastructure.Validation
{
    public class RecipeValidator : AbstractValidator<RecipeDto>
    {
        public RecipeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(5)
                .WithMessage("Your recipe name is too short")
                .MaximumLength(30)
                .WithMessage("Your recipe name is too long");

            RuleFor(x => x.RecipeBody)
                .MinimumLength(30)
                .WithMessage("Your recipe body is too short")
                .MaximumLength(500)
                .WithMessage("Your recipe body is too long")
                .NotEmpty();

            RuleFor(x => x.WaterTemperature)
                .LessThanOrEqualTo(100)
                .WithMessage("Temperature of water can't be higher than 100 °C")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Temperature of water can't be lower than 0 °C");

            RuleFor(x => x.CoffeeAmount)
                .LessThanOrEqualTo(100)
                .WithMessage("That is too much coffee")
                .GreaterThanOrEqualTo(8)
                .WithMessage("That is too little of coffee")
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.WaterAmount)
                .GreaterThanOrEqualTo(50)
                .WithMessage("That is too little water")
                .LessThanOrEqualTo(5000)
                .WithMessage("That is too much water")
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.GrindLevel)
                .IsInEnum();

            RuleFor(x => x.IntendedUse)
                .IsInEnum();
        }
    }
}
