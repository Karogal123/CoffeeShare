using CoffeeShare.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Services.Interfaces
{
    public interface IRecipeService : IService
    {
        Task<List<RecipeDto>> GetAllRecipes();
        Task<RecipeDto> GetRecipeById(int id);
        Task CreateRecipe(RecipeDto recipeDto);
        Task DeleteRecipe(RecipeDto recipeDto);
        Task UpdateRecipe(RecipeDto recipeDto, int id);
    }
}
