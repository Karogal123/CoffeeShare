using CoffeeShare.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Repositories
{
    public interface ICoffeeRepository : IRepository
    {
        Task<List<Coffee>> GetAllCoffees();
        Task<Coffee> GetCoffeeById(int id);
        Task CreateCoffee(Coffee coffee);
        Task DeleteCoffee(Coffee coffee);
        Task UpdateCoffee(Coffee coffee);
    }
}
