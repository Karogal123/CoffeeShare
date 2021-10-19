using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoffeeShare.Core.Dto;
using CoffeeShare.Infrastructure.Repositories;

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
