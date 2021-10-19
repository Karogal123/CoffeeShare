using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;

namespace CoffeeShare.Infrastructure.Services
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
