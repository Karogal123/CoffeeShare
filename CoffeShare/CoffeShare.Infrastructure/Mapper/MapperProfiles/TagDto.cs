using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Infrastructure.Mapper.MapperProfiles
{
    public class TagDto : Profile
    {
        public TagDto()
        {
            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();
        }
    }
}
