using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.DataContext;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CoffeeContext _context;

        public CommentRepository(CoffeeContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllCommentsForRecipe(int recipeId)
            => await _context.Comments.Where(x => x.RecipeId == recipeId).ToListAsync();

        public async Task CreateComment(Comment comment)
        {
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCoffee(Comment comment)
        {
            _context.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}
