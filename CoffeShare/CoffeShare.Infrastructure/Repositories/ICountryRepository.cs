using CoffeeShare.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Repositories
{
    public interface ICountryRepository : IRepository
    {
        Task<List<Country>> GetAllCountries();
    }
}
