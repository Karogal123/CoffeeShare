using AutoMapper;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Infrastructure.Mapper.MapperProfiles
{
    public class RecipeTagDto : Profile
    {
        public RecipeTagDto()
        {
            CreateMap<RecipeTag, RecipeTagDto>();
            CreateMap<RecipeTagDto, RecipeTag>();
        }
    }
}
