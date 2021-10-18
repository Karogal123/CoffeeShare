using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.DataContext;

namespace CoffeeShare.Infrastructure.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly CoffeeContext _context;

        public RecipeRepository(CoffeeContext context)
        {
            _context = context;
        }

        public async Task<List<Recipe>> GetAllRecipes()
            => await _context.Recipes.ToListAsync();

        public async Task<Recipe> GetRecipeById(int id)
            => await _context.Recipes.SingleOrDefaultAsync(x => x.Id == id);

        public async Task CreateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
