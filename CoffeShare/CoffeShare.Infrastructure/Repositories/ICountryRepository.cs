using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Infrastructure.Repositories
{
    public interface ICountryRepository : IRepository
    {
        Task<List<Country>> GetAllCountries();
    }
}
