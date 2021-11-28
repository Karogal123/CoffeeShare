using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoffeeShare.Core.Dto;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Infrastructure.Mapper
{
    class CommentResolver : AutoMapper.IValueResolver<CommentDto, Comment, DateTime>
    {
        public DateTime Resolve(CommentDto source, Comment destination, DateTime destMember, ResolutionContext context)
        {
            return destination.CreatedDate;
        }
    }
}
