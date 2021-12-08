using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;
using FluentValidation;

namespace CoffeeShare.Infrastructure.Validation
{
    public class RecipeScoreValidation : AbstractValidator<RecipeScoreDto>
    {
        public RecipeScoreValidation()
        {
            RuleFor(x => x.Score)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(10)
                .NotEmpty();
        }
    }
}
