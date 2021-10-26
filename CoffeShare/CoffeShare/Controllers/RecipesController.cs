using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;
using CoffeeShare.Infrastructure.Services;

namespace CoffeeShare.Controllers
{
    [ApiController]
    [Route("Recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            var recipes = await _recipeService.GetAllRecipes();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeById(int id)
        {
            var recipe = await _recipeService.GetRecipeById(id);
            if (recipe is null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(RecipeDto recipeDto)
        {
            await _recipeService.CreateRecipe(recipeDto);
            return CreatedAtAction(nameof(GetRecipeById), new { Id = recipeDto.Id }, recipeDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var recipe = await _recipeService.GetRecipeById(id);
            if (recipe is null)
            {
                return NotFound();
            }

            await _recipeService.DeleteRecipe(recipe);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(int id, RecipeDto recipeDto)
        {
            var recipe = await _recipeService.GetRecipeById(id);
            if (recipe is null)
            {
                return NotFound();
            }

            await _recipeService.UpdateRecipe(recipeDto, id);
            return Ok();
        }
    }
}
