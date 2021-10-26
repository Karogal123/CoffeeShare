using CoffeeShare.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Services.Interfaces
{
    public interface IManufacturerService : IService
    {
        Task<List<ManufacturerDto>> GetAllManufacturers();
        Task<ManufacturerDto> GetManufacturerById(int id);
        Task CreateManufacturer(ManufacturerDto manufacturerDto);
        Task DeleteManufacturer(ManufacturerDto manufacturerDto);
        Task UpdateManufacturer(ManufacturerDto manufacturerDto, int id);

    }
}
