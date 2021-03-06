using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.DataContext;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CoffeeShare.Infrastructure.Repositories.Interfaces;

namespace CoffeeShare.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly CoffeeContext _context;

        public CountryRepository(CoffeeContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllCountries()
            => await _context.Countries.OrderBy(x => x.Name).ToListAsync();
    }
}
