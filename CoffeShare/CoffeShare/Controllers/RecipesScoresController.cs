using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;
using CoffeeShare.Infrastructure.DataContext;
using CoffeeShare.Infrastructure.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace CoffeeShare.Controllers
{
    [ApiController]
    [Route("RecipesScores")]
    public class RecipesScoresController : ControllerBase
    {
        private readonly IRecipeScoreService _recipeScoreService;
        private readonly IRecipeService _recipeService;
        private readonly CoffeeContext _context;

        public RecipesScoresController(IRecipeScoreService recipeScoreService, IRecipeService recipeService, CoffeeContext context)
        {
            _recipeScoreService = recipeScoreService;
            _recipeService = recipeService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetScoresForRecipe(int recipeId)
        {
            var recipe = await _recipeService.GetRecipeById(recipeId);
            if (recipe is null)
            {
                return NotFound();
            }

            var scores = await _recipeScoreService.GetScoresForRecipe(recipeId);
            return Ok(scores);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipeScore(RecipeScoreDto recipeScoreDto)
        {
            var claims = User.Claims.FirstOrDefault();
            var user = _context.Users.SingleOrDefault(x => x.Email == claims.Value);
            recipeScoreDto.UserId = user.Id;
            await _recipeScoreService.CreateRecipeScore(recipeScoreDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipeScore(RecipeScoreDto recipeScoreDto, int id)
        {
            var recipeScore = await _recipeScoreService.GetRecipeScoreById(id);
            if (recipeScore is null)
            {
                return NotFound();
            }

            await _recipeScoreService.UpdateRecipeScore(recipeScoreDto);
            return Ok();
        }
    }
}
