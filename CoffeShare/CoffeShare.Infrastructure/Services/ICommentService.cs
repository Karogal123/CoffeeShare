using CoffeeShare.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Services
{
    public interface ICommentService : IService
    {
        Task<List<CommentDto>> GetAllCommentsForRecipe(int recipeId);
        Task CreateComment(CommentDto commentDto);
        Task DeleteCoffee(CommentDto commentDto);
    }
}
