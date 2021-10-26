using CoffeeShare.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;

namespace CoffeeShare.Controllers
{
    [ApiController]
    [Route("Comments")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommentsForRecipe(int id)
        {
            var comments = await _commentService.GetAllCommentsForRecipe(id);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentDto commentDto)
        {
            await _commentService.CreateComment(commentDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _commentService.GetCommentById(id);
            if (comment is null)
            {
                return NotFound();
            }

            await _commentService.DeleteCoffee(comment);
            return Ok();
        }
    }
}
