using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Infrastructure.Repositories
{
    public interface ICommentRepository : IRepository
    {
        Task<List<Comment>> GetAllCommentsForRecipe(int recipeId);
        Task CreateComment(Comment comment);
        Task DeleteCoffee(Comment comment);
    }
}
