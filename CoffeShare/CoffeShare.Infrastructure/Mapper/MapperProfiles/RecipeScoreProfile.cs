using AutoMapper;
using CoffeeShare.Core.Dto;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Infrastructure.Mapper.MapperProfiles
{
    public class RecipeScoreProfile : Profile
    {
        public RecipeScoreProfile()
        {
            CreateMap<RecipeScore, RecipeScoreDto>();
            CreateMap<RecipeScoreDto, RecipeScore>();
        }
    }
}
