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
            RuleFor(x => x.RecipeBody)
                .MinimumLength(50)
                .MinimumLength(500)
                .NotEmpty()
                .WithMessage("Recipe body must contain at least 50 chars and not more than 500");
        }
    }
}
