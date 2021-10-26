using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;

namespace CoffeeShare.Infrastructure.Services.Interfaces
{
    public interface IRecipeScoreService : IService
    {
        Task<List<RecipeScoreDto>> GetScoresForRecipe(int id);
        Task<RecipeScoreDto> GetRecipeScoreById(int id);
        Task CreateRecipeScore (RecipeScoreDto recipeScoreDto);
        Task UpdateRecipeScore(RecipeScoreDto recipeScoreDto);
    }
}
