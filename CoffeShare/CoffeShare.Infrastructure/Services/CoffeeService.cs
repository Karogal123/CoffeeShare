using AutoMapper;
using CoffeeShare.Core.Dto;
using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeShare.Infrastructure.Repositories.Interfaces;
using CoffeeShare.Infrastructure.Services.Interfaces;

namespace CoffeeShare.Infrastructure.Services
{
    public class CoffeeService : ICoffeeService
    {
        private readonly ICoffeeRepository _coffeeRepository;
        private readonly IMapper _mapper;

        public CoffeeService(ICoffeeRepository coffeeRepository, IMapper mapper)
        {
            _coffeeRepository = coffeeRepository;
            _mapper = mapper;
        }

        public async Task<List<CoffeeDto>> GetAllCoffees()
        {
            var coffeesModels = await _coffeeRepository.GetAllCoffees();
            return _mapper.Map<List<CoffeeDto>>(coffeesModels);
        }

        public async Task<CoffeeDto> GetCoffeeById(int id)
        {
            var coffeeModel = await _coffeeRepository.GetCoffeeById(id);
            return _mapper.Map<CoffeeDto>(coffeeModel);
        }

        public async Task CreateCoffee(CoffeeDto coffeeDto)
        {
            var coffeeModel = _mapper.Map<Coffee>(coffeeDto);
            await _coffeeRepository.CreateCoffee(coffeeModel);
        }

        public async Task DeleteCoffee(CoffeeDto coffeeDto)
        {
            var coffeeModel = _mapper.Map<Coffee>(coffeeDto);
            await _coffeeRepository.DeleteCoffee(coffeeModel);
        }

        public async Task UpdateCoffee(CoffeeDto coffeeDto, int id)
        {
            var coffeeModel = await _coffeeRepository.GetCoffeeById(id);
            var coffeeUpdate = _mapper.Map(coffeeDto, coffeeModel);
            await _coffeeRepository.UpdateCoffee(coffeeUpdate);
        }
    }
}
