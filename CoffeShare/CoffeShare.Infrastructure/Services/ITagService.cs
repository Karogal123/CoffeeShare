using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Infrastructure.Services
{
    public interface ITagService : IService
    {
        Task<List<TagDto>> GetAllTags();
        Task<TagDto> GetTagById();
        Task CreateTag(TagDto tagDto);
        Task DeleteTag(TagDto tagDto);
        Task UpdateTag(TagDto tagDto);
    }
}
