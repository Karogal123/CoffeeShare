using CoffeeShare.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Services.Interfaces
{
    public interface ICountryService : IService
    {
        Task<List<CountryDto>> GetAllCountries();
    }
}
