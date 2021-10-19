using CoffeeShare.Core.Dto;
using CoffeeShare.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShare.Controllers
{
    [ApiController]
    [Route("Coffee")]
    public class CoffeesController : ControllerBase
    {
        private readonly ICoffeeService _coffeeService;
        public CoffeesController(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        [HttpGet]
        public async Task<List<CoffeeDto>> GetAllCoffees()
        {
            var coffees = _coffeeService.GetAllCoffees();
        }
    }
}
