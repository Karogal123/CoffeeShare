using CoffeeShare.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Repositories.Interfaces
{
    public interface ITagRepository : IRepository
    {
        Task<List<Tag>> GetAllTags();
        Task<Tag> GetTagById(int id);
        Task CreateTag(Tag tag);
        Task DeleteTag(Tag tag);
        Task UpdateTag(Tag tag);
    }
}
