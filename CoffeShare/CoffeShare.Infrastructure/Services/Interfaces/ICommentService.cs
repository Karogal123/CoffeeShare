using CoffeeShare.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Services.Interfaces
{
    public interface ICommentService : IService
    {
        Task<List<CommentDto>> GetAllCommentsForRecipe(int recipeId);
        Task<CommentDto> GetCommentById(int id);
        Task CreateComment(CommentDto commentDto);
        Task DeleteCoffee(CommentDto commentDto);
    }
}
