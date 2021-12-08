using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;
using FluentValidation;

namespace CoffeeShare.Infrastructure.Validation
{
    public class CommentValidation : AbstractValidator<CommentDto>
    {
        public CommentValidation()
        {
            RuleFor(x => x.CommentBody)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(150);
        }
    }
}
