using CoffeeShare.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Services
{
    public interface ITagService : IService
    {
        Task<List<TagDto>> GetAllTags();
        Task<TagDto> GetTagById(int id);
        Task CreateTag(TagDto tagDto);
        Task DeleteTag(TagDto tagDto);
        Task UpdateTag(TagDto tagDto, int id);
    }
}
