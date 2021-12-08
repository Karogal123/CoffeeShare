using CoffeeShare.Core.Dto;
using CoffeeShare.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CoffeeShare.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoffeeShare.Controllers
{
    [ApiController]
    [Route("Manufacturers")]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturersController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllManufacturers()
        {
            var manufacturers = await _manufacturerService.GetAllManufacturers();
            return Ok(manufacturers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetManufacturerById(int id)
        {
            var manufacturer = await _manufacturerService.GetManufacturerById(id);
            if (manufacturer is null)
            {
                return NotFound();
            }

            return Ok(manufacturer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateManufacturer(ManufacturerDto manufacturerDto)
        {
            await _manufacturerService.CreateManufacturer(manufacturerDto);
            return CreatedAtAction(nameof(GetManufacturerById), new { Id = manufacturerDto.Id }, manufacturerDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturer(int id)
        {
            var manufacturer = await _manufacturerService.GetManufacturerById(id);
            if (manufacturer is null)
            {
                return NotFound();
            }
            await _manufacturerService.DeleteManufacturer(manufacturer);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateManufacturer(int id, ManufacturerDto manufacturerDto)
        {
            var manufacturer = await _manufacturerService.GetManufacturerById(id);
            if (manufacturer is null)
            {
                return NotFound();
            }

            await _manufacturerService.UpdateManufacturer(manufacturerDto, id);
            return Ok();
        }
    }
}
