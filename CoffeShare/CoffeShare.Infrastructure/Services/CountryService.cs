using AutoMapper;
using CoffeeShare.Core.Dto;
using CoffeeShare.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository repository, IMapper map)
        {
            _countryRepository = repository;
            _mapper = map;
        }

        public async Task<List<CountryDto>> GetAllCountries()
        {
            var countriesModels = await _countryRepository.GetAllCountries();
            return _mapper.Map<List<CountryDto>>(countriesModels);
        }
    }
}
