using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Infrastructure.Repositories.Interfaces
{
    public interface IRecipeTagRepository : IRepository
    {
        Task<List<RecipeTag>> GetTagsForRecipe(int recipeId);
        Task<RecipeTag> GetRecipeTagById(int id);
        Task CreateRecipeTag(RecipeTag recipeTag);
        Task UpdateRecipeTag(RecipeTag recipeTag);
    }
}
