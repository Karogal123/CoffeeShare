using System;
using System.Linq;
using System.Security.Claims;
using CoffeeShare.Core.Dto;
using CoffeeShare.Infrastructure.Services;
using CoffeeShare.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.DataContext;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CoffeeShare.Controllers
{
    [ApiController]
    [Route("Recipes")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CoffeeContext _context;

        public RecipesController(IRecipeService recipeService, IHttpContextAccessor httpContextAccessor, CoffeeContext context)
        {
            _recipeService = recipeService;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            var recipes = await _recipeService.GetAllRecipes();
            return Ok(recipes);
        }

        [HttpGet]
        [Route("GetById/{id}")]
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
        [Authorize]
        public async Task<IActionResult> CreateRecipe(RecipeDto recipeDto)
        {
            var claims = User.Claims.FirstOrDefault();
            var user = _context.Users.SingleOrDefault(x => x.Email == claims.Value);
            recipeDto.UserId = user.Id;
            await _recipeService.CreateRecipe(recipeDto);
            return CreatedAtAction(nameof(GetRecipeById), new { Id = recipeDto.Id }, recipeDto);
        }

        [HttpDelete("{id}")]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> UpdateRecipe(int id, RecipeDto recipeDto)
        {
            var admins = _context.UserRoles.Where(x => x.RoleId == 2).Select(x => x.UserId);
            var claims = User.Claims.FirstOrDefault();
            var user = _context.Users.SingleOrDefault(x => x.Email == claims.Value);
            if (recipeDto.UserId != user.Id)
            {
                throw new Exception("Unauthorized action");
            }
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
