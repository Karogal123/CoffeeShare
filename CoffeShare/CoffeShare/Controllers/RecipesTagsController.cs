using CoffeeShare.Core.Dto;
using CoffeeShare.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShare.Controllers
{
    [ApiController]
    [Route("RecipesTags")]
    public class RecipesTagsController : ControllerBase
    {
        private readonly IRecipeTagService _recipeTagService;
        private readonly IRecipeService _recipeService;

        public RecipesTagsController(IRecipeTagService recipeTagService, IRecipeService recipeService)
        {
            _recipeTagService = recipeTagService;
            _recipeService = recipeService;
        }

        [HttpGet("{recipeId}")]
        public async Task<IActionResult> GetTagsForRecipe(int recipeId)
        {
            var recipe = await _recipeService.GetRecipeById(recipeId);
            if(recipe is null)
            {
                return NotFound();
            }
            var recipeTags = _recipeTagService.GetTagsForRecipe(recipeId);
            return Ok(recipeTags);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipeScore(RecipeTagDto recipetagDto)
        {
            await _recipeTagService.CreateRecipeTag(recipetagDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipeScore(RecipeTagDto recipeTagDto, int id)
        {
            var recipeScore = await _recipeTagService.GetRecipeTagById(id);
            if (recipeScore is null)
            {
                return NotFound();
            }

            await _recipeTagService.UpdateRecipeTag(recipeTagDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = await _recipeTagService.GetRecipeTagById(id);
            if (tag is null)
            {
                return NotFound();
            }

            await _recipeTagService.DeleteRecipeTag(tag);
            return Ok();
        }

    }
}
