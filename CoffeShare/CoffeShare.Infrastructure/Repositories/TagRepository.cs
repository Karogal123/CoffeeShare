using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.DataContext;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CoffeeShare.Infrastructure.Repositories.Interfaces;

namespace CoffeeShare.Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly CoffeeContext _context;

        public TagRepository(CoffeeContext context)
        {
            _context = context;
        }

        public async Task<List<Tag>> GetAllTags()
            => await _context.Tags.ToListAsync();

        public async Task<Tag> GetTagById(int id)
            => await _context.Tags.SingleOrDefaultAsync(x => x.Id == id);

        public async Task CreateTag(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTag(Tag tag)
        {
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTag(Tag tag)
        {
            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();
        }
    }
}
