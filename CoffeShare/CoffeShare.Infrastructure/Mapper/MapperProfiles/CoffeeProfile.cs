using AutoMapper;
using CoffeeShare.Core.Dto;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Infrastructure.Mapper.MapperProfiles
{
    public class CoffeeProfile : Profile
    {
        public CoffeeProfile()
        {
            CreateMap<Coffee, CoffeeDto>();
            CreateMap<CoffeeDto, Coffee>();
        }
    }
}
