using CoffeeShare.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Repositories.Interfaces
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
