using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Infrastructure.Repositories.Interfaces
{
    public interface IRecipeScoreRepository : IRepository
    {
        Task<List<RecipeScore>> GetAllScoresForRecipe(int id);
        Task<RecipeScore> GetRecipeScoreById(int id);
        Task CreateRecipeScore(RecipeScore recipeScore);
        Task UpdateRecipeScore(RecipeScore recipeScore);
    }
}
