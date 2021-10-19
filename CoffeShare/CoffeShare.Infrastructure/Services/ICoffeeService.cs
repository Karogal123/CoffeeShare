using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Infrastructure.Services
{
    public interface ICoffeeService : IService
    {
        Task<List<CoffeeDto>> GetAllCoffee();
        Task<CoffeeDto> GetCoffeeById(int id);
        Task CreateCoffee(CoffeeDto coffeeDto);
        Task DeleteCoffee(CoffeeDto coffeeDto);
        Task UpdateCoffee(CoffeeDto coffeeDto, int id);
    }
}
