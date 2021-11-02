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
    public class RecipeTagService : IRecipeTagService
    {
        private readonly IRecipeTagRepository _recipeTagRepository;
        private readonly IMapper _mapper;

        public RecipeTagService(IMapper mapper, IRecipeTagRepository recipeTagRepository)
        {
            _mapper = mapper;
            _recipeTagRepository = recipeTagRepository;
        }

        public async Task<List<RecipeTagDto>> GetTagsForRecipe(int recipeId)
        {
            var recipeTags = await _recipeTagRepository.GetTagsForRecipe(recipeId);
            return _mapper.Map<List<RecipeTagDto>>(recipeTags);
        }

        public async Task<RecipeTagDto> GetRecipeTagById(int id)
        {
            var recipeTag = await _recipeTagRepository.GetRecipeTagById(id);
            return _mapper.Map<RecipeTagDto>(recipeTag);
        }

        public async Task CreateRecipeTag(RecipeTagDto recipeTagDto)
        {
            var recipeTag = _mapper.Map<RecipeTag>(recipeTagDto);
            await _recipeTagRepository.CreateRecipeTag(recipeTag);
        }

        public async Task UpdateRecipeTag(RecipeTagDto recipeTagDto)
        {
            var recipeTag = await _recipeTagRepository.GetRecipeTagById(recipeTagDto.Id);
            var recipeTagUpdate = _mapper.Map(recipeTag, recipeTag);
            await _recipeTagRepository.UpdateRecipeTag(recipeTagUpdate);
        }

        public async Task DeleteRecipeTag(RecipeTagDto recipeTagDto)
        {
            var recipeTag =  _mapper.Map<RecipeTag>(recipeTagDto);
            await _recipeTagRepository.DeleteRecipeTag(recipeTag);
        }
    }
}
