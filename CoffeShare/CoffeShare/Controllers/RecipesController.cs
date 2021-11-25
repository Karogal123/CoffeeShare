using System;
using System.Security.Claims;
using CoffeeShare.Core.Dto;
using CoffeeShare.Infrastructure.Services;
using CoffeeShare.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CoffeeShare.Controllers
{
    [ApiController]
    
    [Route("Recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;

        public RecipesController(IRecipeService recipeService, Microsoft.AspNetCore.Identity.UserManager<User> userManager)
        {
            _recipeService = recipeService;
            _userManager = userManager;
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
            var userId = IdentityExtensions.GetUserId(User.Identity);
            recipeDto.UserId = int.Parse(userId);
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
