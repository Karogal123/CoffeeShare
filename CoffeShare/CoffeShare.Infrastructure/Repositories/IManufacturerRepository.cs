using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Infrastructure.Repositories
{
    public interface IManufacturerRepository : IRepository
    {
        Task<List<Manufacturer>> GetAllManufacturers();
        Task<Manufacturer> GetManufacturerById(int id);
        Task CreateManufacturer(Manufacturer manufacturer);
        Task DeleteManufacturer(Manufacturer manufacturer);
        Task UpdateManufacturer(Manufacturer manufacturer);
    }
}
