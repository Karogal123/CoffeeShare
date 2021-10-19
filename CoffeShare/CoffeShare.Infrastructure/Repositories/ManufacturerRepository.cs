using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.DataContext;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly CoffeeContext _context;

        public ManufacturerRepository(CoffeeContext context)
        {
            _context = context;
        }

        public async Task<List<Manufacturer>> GetAllManufacturers()
            => await _context.Manufacturers.ToListAsync();

        public async Task<Manufacturer> GetManufacturerById(int id)
            => await _context.Manufacturers.SingleOrDefaultAsync(x => x.Id == id);

        public async Task CreateManufacturer(Manufacturer manufacturer)
        {
            await _context.Manufacturers.AddAsync(manufacturer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteManufacturer(Manufacturer manufacturer)
        {
            _context.Manufacturers.Remove(manufacturer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateManufacturer(Manufacturer manufacturer)
        {
            _context.Manufacturers.Update(manufacturer);
            await _context.SaveChangesAsync();
        }
    }
}
