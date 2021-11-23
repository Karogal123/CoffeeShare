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
                .GreaterThan(0)
                .LessThan(11)
                .WithMessage("Score can not be lower than 0 and greater than 10");
        }
    }
}
