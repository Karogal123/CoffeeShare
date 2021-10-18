using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Infrastructure.Repositories
{
    public interface ITagRepository : IRepository
    {
        Task<List<Tag>> GetAllTags();
        Task<Tag> GetTagById(int id);
        Task CreateTag(Tag tag);
        Task DeleteCoffee(Tag tag);
        Task UpdateCoffee(Tag tag);
    }
}
