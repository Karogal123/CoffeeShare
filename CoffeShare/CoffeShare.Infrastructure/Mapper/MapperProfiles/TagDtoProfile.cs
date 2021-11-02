using AutoMapper;
using CoffeeShare.Core.Dto;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Infrastructure.Mapper.MapperProfiles
{
    public class TagDtoProfile : Profile
    {
        public TagDtoProfile()
        {
            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();
        }
    }
}
