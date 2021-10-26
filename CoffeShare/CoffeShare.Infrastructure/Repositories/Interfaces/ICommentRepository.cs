using CoffeeShare.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Repositories.Interfaces
{
    public interface ICommentRepository : IRepository
    {
        Task<List<Comment>> GetAllCommentsForRecipe(int recipeId);
        Task<Comment> GetCommentById(int id);
        Task CreateComment(Comment comment);
        Task DeleteCoffee(Comment comment);
    }
}
