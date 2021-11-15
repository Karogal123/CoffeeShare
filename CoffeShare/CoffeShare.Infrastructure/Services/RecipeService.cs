using AutoMapper;
using CoffeeShare.Core.Dto;
using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeShare.Infrastructure.Repositories.Interfaces;
using CoffeeShare.Infrastructure.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace CoffeeShare.Infrastructure.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<List<RecipeDto>> GetAllRecipes()
        {
            var recipesModels = await _recipeRepository.GetAllRecipes();
            return _mapper.Map<List<RecipeDto>>(recipesModels);
        }

        public async Task<RecipeDto> GetRecipeById(int id)
        {
            var recipeModel = await _recipeRepository.GetRecipeById(id);
            return _mapper.Map<RecipeDto>(recipeModel);
        }

        public async Task CreateRecipe(RecipeDto recipeDto)
        {
            var recipeModel = _mapper.Map<Recipe>(recipeDto);
            await _recipeRepository.CreateRecipe(recipeModel);
        }

        public async Task DeleteRecipe(RecipeDto recipeDto)
        {
            var recipeModel = _mapper.Map<Recipe>(recipeDto);
            await _recipeRepository.DeleteRecipe(recipeModel);
        }

        public async Task UpdateRecipe(RecipeDto recipeDto, int id)
        {
            var recipeModel = await _recipeRepository.GetRecipeById(id);
            var recipeUpdate = _mapper.Map(recipeDto, recipeModel);
            await _recipeRepository.UpdateRecipe(recipeUpdate);
        }
    }
}
