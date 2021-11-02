using AutoMapper;
using CoffeeShare.Core.Dto;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Infrastructure.Mapper.MapperProfiles
{
    public class RecipeTagDtoProfile : Profile
    {
        public RecipeTagDtoProfile()
        {
            CreateMap<RecipeTag, RecipeTagDto>();
            CreateMap<RecipeTagDto, RecipeTag>();
        }
    }
}
