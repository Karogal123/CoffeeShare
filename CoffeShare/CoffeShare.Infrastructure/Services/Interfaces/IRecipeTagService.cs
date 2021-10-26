using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;

namespace CoffeeShare.Infrastructure.Services.Interfaces
{
    public interface IRecipeTagService : IService
    {
        Task<List<RecipeTagDto>> GetTagsForRecipe(int recipeId);
        Task<RecipeTagDto> GetRecipeTagById(int id);
        Task CreateRecipeTag(RecipeTagDto recipeTagDto);
        Task UpdateRecipeTag(RecipeTagDto recipeTagDto);
        Task DeleteRecipeTag(RecipeTagDto recipeTagDto);
    }
}
