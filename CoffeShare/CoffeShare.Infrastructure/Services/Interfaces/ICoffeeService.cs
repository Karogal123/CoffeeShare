using CoffeeShare.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Services.Interfaces
{
    public interface ICoffeeService : IService
    {
        Task<List<CoffeeDto>> GetAllCoffees();
        Task<CoffeeDto> GetCoffeeById(int id);
        Task CreateCoffee(CoffeeDto coffeeDto);
        Task DeleteCoffee(CoffeeDto coffeeDto);
        Task UpdateCoffee(CoffeeDto coffeeDto, int id);
    }
}
