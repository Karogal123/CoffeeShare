using CoffeeShare.Core.Dto;
using CoffeeShare.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CoffeeShare.Infrastructure.Services.Interfaces;

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
        public async Task<IActionResult> GetAllCoffees()
        {
            var coffees = await _coffeeService.GetAllCoffees();
            return Ok(coffees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoffeeById(int id)
        {
            var coffee = await _coffeeService.GetCoffeeById(id);
            if (coffee is null)
            {
                return NotFound();
            }

            return Ok(coffee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoffee(CoffeeDto coffeeDto)
        {
            await _coffeeService.CreateCoffee(coffeeDto);
            return CreatedAtAction(nameof(GetCoffeeById), new { Id = coffeeDto.Id }, coffeeDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoffee(int id)
        {
            var coffeeDto = await _coffeeService.GetCoffeeById(id);
            if (coffeeDto is null)
            {
                return NotFound();
            }

            await _coffeeService.DeleteCoffee(coffeeDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoffee(CoffeeDto coffeeDto, int id)
        {
            var coffee = await _coffeeService.GetCoffeeById(id);
            if (coffee is null)
            {
                return NotFound();
            }

            await _coffeeService.UpdateCoffee(coffeeDto, id);
            return Ok();
        }

    }
}
