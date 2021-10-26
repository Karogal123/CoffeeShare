using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;
using CoffeeShare.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShare.Controllers
{
    [ApiController]
    [Route("Tags")]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await _tagService.GetAllTags();
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var tag = await _tagService.GetTagById(id);
            if (tag is null)
            {
                return NotFound();
            }

            return Ok(tag);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(TagDto tagDto)
        {
            await _tagService.CreateTag(tagDto);
            return CreatedAtAction(nameof(GetTagById), new { Id = tagDto.Id }, tagDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = await _tagService.GetTagById(id);
            if (tag is null)
            {
                return NotFound();
            }

            await _tagService.DeleteTag(tag);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updatetag(int id, TagDto tagDto)
        {
            var tag = await _tagService.GetTagById(id);
            if (tag is null)
            {
                return NotFound();
            }

            await _tagService.UpdateTag(tagDto, id);
            return Ok();
        }
    }
}
