using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoffeeShare.Core.Dto;
using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.Repositories.Interfaces;
using CoffeeShare.Infrastructure.Services.Interfaces;

namespace CoffeeShare.Infrastructure.Services
{
    public class RecipeScoreService : IRecipeScoreService
    {
        private readonly IRecipeScoreRepository _recipeScoreRepository;
        private readonly IMapper _mapper;

        public RecipeScoreService(IRecipeScoreRepository recipeScoreRepository, IMapper mapper)
        {
            _recipeScoreRepository = recipeScoreRepository;
            _mapper = mapper;
        }

        public async Task<List<RecipeScoreDto>> GetScoresForRecipe(int id)
        {
            var scores = await _recipeScoreRepository.GetAllScoresForRecipe(id);
            return _mapper.Map<List<RecipeScoreDto>>(scores);
        }

        public async Task<RecipeScoreDto> GetRecipeScoreById(int id)
        {
            var score = await _recipeScoreRepository.GetRecipeScoreById(id);
            return _mapper.Map<RecipeScoreDto>(score);
        }

        public async Task CreateRecipeScore(RecipeScoreDto recipeScoreDto)
        {
            var recipe = _mapper.Map<RecipeScore>(recipeScoreDto);
            await _recipeScoreRepository.CreateRecipeScore(recipe);
        }

        public async Task UpdateRecipeScore(RecipeScoreDto recipeScoreDto)
        {
            var recipe = _mapper.Map<RecipeScore>(recipeScoreDto);
            await _recipeScoreRepository.UpdateRecipeScore(recipe);
        }
    }
}
