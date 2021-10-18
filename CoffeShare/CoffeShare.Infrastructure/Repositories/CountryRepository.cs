using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.DataContext;

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
            => await _context.Countries.ToListAsync();
    }
}
