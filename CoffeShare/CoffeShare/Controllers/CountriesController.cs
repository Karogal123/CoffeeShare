using System.Security.Cryptography.X509Certificates;
using CoffeeShare.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CoffeeShare.Controllers
{
    [ApiController]
    [Route("Countries")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;


        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _countryService.GetAllCountries();
            return Ok(countries);
        }
    }
}
