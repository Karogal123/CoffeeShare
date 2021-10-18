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
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly CoffeeContext _context;

        public CoffeeRepository(CoffeeContext context)
        {
            _context = context;
        }

        public async Task<List<Coffee>> GetAllCoffees()
            => await _context.Coffees.ToListAsync();

        public async Task<Coffee> GetCoffeeById(int id)
            => await _context.Coffees.SingleOrDefaultAsync(x => x.Id == id);

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
