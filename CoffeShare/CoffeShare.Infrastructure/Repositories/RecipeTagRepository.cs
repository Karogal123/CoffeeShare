using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.DataContext;
using CoffeeShare.Infrastructure.Repositories.Interfaces;

namespace CoffeeShare.Infrastructure.Repositories
{
    public class RecipeTagRepository : IRecipeTagRepository
    {
        private readonly CoffeeContext _context;

        public RecipeTagRepository(CoffeeContext context)
        {
            _context = context;
        }

        public async Task<List<RecipeTag>> GetTagsForRecipe(int recipeId)
            => await _context.RecipeTags.Include(x => x.Recipe).Include(x => x.Tag).Where(x => x.RecipeId == recipeId).ToListAsync();

        public async Task<RecipeTag> GetRecipeTagById(int id)
            => await _context.RecipeTags.Include(x => x.Recipe).Include(x => x.Tag).SingleOrDefaultAsync(x => x.Id == id);

        public async Task CreateRecipeTag(RecipeTag recipeTag)
        {
            await _context.RecipeTags.AddAsync(recipeTag);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRecipeTag(RecipeTag recipeTag)
        {
            _context.RecipeTags.Update(recipeTag);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecipeTag(RecipeTag recipeTag)
        {
            _context.RecipeTags.Remove(recipeTag);
            await _context.SaveChangesAsync();
        }
    }
}
