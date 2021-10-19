using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;

namespace CoffeeShare.Infrastructure.Services
{
    public interface ICountryService : IService
    {
        Task<List<CountryDto>> GetAllCountries();
    }
}
