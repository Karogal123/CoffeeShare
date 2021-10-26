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
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;

        public ManufacturerService(IManufacturerRepository manufacturerRepository, IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        public async Task<List<ManufacturerDto>> GetAllManufacturers()
        {
            var manufacturersModels = await _manufacturerRepository.GetAllManufacturers();
            return _mapper.Map<List<ManufacturerDto>>(manufacturersModels);
        }

        public async Task<ManufacturerDto> GetManufacturerById(int id)
        {
            var manufacturerModel = await _manufacturerRepository.GetManufacturerById(id);
            return _mapper.Map<ManufacturerDto>(manufacturerModel);
        }

        public async Task CreateManufacturer(ManufacturerDto manufacturerDto)
        {
            var manufacturerModel = _mapper.Map<Manufacturer>(manufacturerDto);
            await _manufacturerRepository.CreateManufacturer(manufacturerModel);
        }

        public async Task DeleteManufacturer(ManufacturerDto manufacturerDto)
        {
            var manufacturerModel = _mapper.Map<Manufacturer>(manufacturerDto);
            await _manufacturerRepository.DeleteManufacturer(manufacturerModel);
        }

        public async Task UpdateManufacturer(ManufacturerDto manufacturerDto, int id)
        {
            var manufacturerModel = await _manufacturerRepository.GetManufacturerById(id);
            var manufacturerUpdate = _mapper.Map(manufacturerDto, manufacturerModel);
            await _manufacturerRepository.UpdateManufacturer(manufacturerUpdate);
        }
    }
}
