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
            await _context.AddAsync(recipeScore);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRecipeScore(RecipeScore recipeScore)
        {
            _context.RecipeScores.Remove(recipeScore);
            await _context.SaveChangesAsync();
        }
    }
}
