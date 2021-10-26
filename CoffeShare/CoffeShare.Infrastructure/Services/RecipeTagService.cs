using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoffeeShare.Core.Dto;
using CoffeeShare.Infrastructure.Services.Interfaces;

namespace CoffeeShare.Infrastructure.Services
{
    public class RecipeTagService : IRecipeTagService
    {
        private readonly IRecipeTagService _recipeTagService;
        private readonly IMapper _mapper;

        public RecipeTagService(IMapper mapper, IRecipeTagService recipeTagService)
        {
            _mapper = mapper;
            _recipeTagService = recipeTagService;
        }

        public async Task<List<RecipeTagDto>> GetTagsForRecipe(int recipeId)
        {
            throw new NotImplementedException();
        }

        public async Task<RecipeTagDto> GetRecipeTagById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateRecipeTag(RecipeTagDto recipeTagDto)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRecipeTag(RecipeTagDto recipeTagDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRecipeTag(RecipeTagDto recipeTagDto)
        {
            throw new NotImplementedException();
        }
    }
}
