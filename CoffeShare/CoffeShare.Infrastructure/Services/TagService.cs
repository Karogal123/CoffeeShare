using AutoMapper;
using CoffeeShare.Core.Dto;
using CoffeeShare.Core.Models;
using CoffeeShare.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeShare.Infrastructure.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<List<TagDto>> GetAllTags()
        {
            var tagsModels = await _tagRepository.GetAllTags();
            return _mapper.Map<List<TagDto>>(tagsModels);
        }

        public async Task<TagDto> GetTagById(int id)
        {
            var tagModel = await _tagRepository.GetTagById(id);
            return _mapper.Map<TagDto>(tagModel);
        }

        public async Task CreateTag(TagDto tagDto)
        {
            var tagModel = _mapper.Map<Tag>(tagDto);
            await _tagRepository.CreateTag(tagModel);
        }

        public async Task DeleteTag(TagDto tagDto)
        {
            var tagModel = _mapper.Map<Tag>(tagDto);
            await _tagRepository.DeleteTag(tagModel);
        }

        public async Task UpdateTag(TagDto tagDto, int id)
        {
            var tagModel = await _tagRepository.GetTagById(id);
            var tagUpdate = _mapper.Map(tagDto, tagModel);
            await _tagRepository.UpdateTag(tagUpdate);
        }
    }
}
