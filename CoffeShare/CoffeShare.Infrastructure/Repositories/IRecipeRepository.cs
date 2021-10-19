using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Infrastructure.Repositories
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
