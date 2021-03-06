using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShare.Infrastructure.Repositories.Interfaces;

namespace CoffeeShare.Infrastructure.Repositories
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly CoffeeContext _context;

        public CoffeeRepository(CoffeeContext context)
        {
            _context = context;
        }

        public async Task<List<Coffee>> GetAllCoffees()
            => await _context.Coffees.Include(x => x.Manufacturer).Include(x => x.Country).OrderBy(x => x.Manufacturer.Name).ThenBy(x => x.Name).ToListAsync();

        public async Task<Coffee> GetCoffeeById(int id)
            => await _context.Coffees.Include(x => x.Manufacturer).AsNoTracking().Include(x => x.Country).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

        public async Task CreateCoffee(Coffee coffee)
        {
            await _context.Coffees.AddAsync(coffee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCoffee(Coffee coffee)
        {
            _context.Coffees.Remove(coffee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCoffee(Coffee coffee)
        {
            _context.Coffees.Update(coffee);
            await _context.SaveChangesAsync();
        }
    }
}
