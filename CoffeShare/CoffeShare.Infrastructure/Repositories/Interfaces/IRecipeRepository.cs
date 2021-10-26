using CoffeeShare.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Repositories.Interfaces
{
    public interface IRecipeRepository : IRepository
    {
        Task<List<Recipe>> GetAllRecipes();
        Task<Recipe> GetRecipeById(int id);
        Task CreateRecipe(Recipe recipe);
        Task DeleteRecipe(Recipe recipe);
        Task UpdateRecipe(Recipe recipe);
    }
}
