using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.DataContext;
using CoffeeShare.Infrastructure.Repositories.Interfaces;

namespace CoffeeShare.Infrastructure.Repositories
{
    public class RecipeScoreRepository : IRecipeScoreRepository
    {
        private readonly CoffeeContext _context;

        public RecipeScoreRepository(CoffeeContext context)
        {
            _context = context;
        }

        public async Task<List<RecipeScore>> GetAllScoresForRecipe(int id)
            => await _context.RecipeScores.Include(x => x.Recipe).Include(x => x.User).Where(x => x.RecipeId == id).ToListAsync();

        public async Task<RecipeScore> GetRecipeScoreById(int id)
            => await _context.RecipeScores.Include(x => x.Recipe).Include(x => x.User).SingleOrDefaultAsync(x => x.Id == id);
        
        public async Task CreateRecipeScore(RecipeScore recipeScore)
        {
            var userScores = _context.RecipeScores.Where(x => x.UserId == recipeScore.UserId);
            if (userScores.Any(x => (x.RecipeId == recipeScore.RecipeId)))
            {
                var scoreInDb = await _context.RecipeScores.SingleOrDefaultAsync(x =>
                    x.UserId == recipeScore.UserId && x.RecipeId == recipeScore.RecipeId);
                scoreInDb.Score = recipeScore.Score;
                await UpdateRecipeScore(scoreInDb);
                await _context.SaveChangesAsync();
                return;
            }
            await _context.AddAsync(recipeScore);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRecipeScore(RecipeScore recipeScore)
        {
            _context.RecipeScores.Update(recipeScore);
            await _context.SaveChangesAsync();
        }
    }
}
