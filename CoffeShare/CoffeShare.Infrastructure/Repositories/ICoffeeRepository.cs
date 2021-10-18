using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;

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
