using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.DataContext;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CoffeeShare.Infrastructure.Repositories.Interfaces;

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
            => await _context.Recipes.AsNoTracking().Include(x => x.User).Include(x => x.Coffee).ThenInclude(x => x.Manufacturer).ToListAsync();

        public async Task<Recipe> GetRecipeById(int id)
            => await _context.Recipes.AsNoTracking().Include(x => x.User).Include(x => x.Coffee).ThenInclude(x => x.Manufacturer).SingleOrDefaultAsync(x => x.Id == id);

        public async Task CreateRecipe(Recipe recipe)
        {
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecipe(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();
        }
    }
}
