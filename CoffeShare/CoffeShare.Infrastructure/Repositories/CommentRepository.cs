using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.DataContext;
using CoffeeShare.Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
            => await _context.Comments.Include(x => x.User).Include(x => x.Recipe).Where(x => x.RecipeId == recipeId).OrderByDescending(x => x.CreatedDate).ToListAsync();

        public async Task<Comment> GetCommentById(int id)
            => await _context.Comments.Include(x => x.User).Include(x => x.Recipe).SingleOrDefaultAsync(x => x.Id == id);

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
