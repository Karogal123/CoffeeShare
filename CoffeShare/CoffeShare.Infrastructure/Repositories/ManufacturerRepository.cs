using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.DataContext;
using CoffeeShare.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            => await _context.Manufacturers.AsNoTracking().OrderBy(x => x.Name).ToListAsync();

        public async Task<Manufacturer> GetManufacturerById(int id)
            => await _context.Manufacturers.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

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
