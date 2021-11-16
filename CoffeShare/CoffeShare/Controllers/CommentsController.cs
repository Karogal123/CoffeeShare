using CoffeeShare.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;
using CoffeeShare.Infrastructure.Services.Interfaces;
using Microsoft.AspNet.Identity;

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
        public async Task<IActionResult> GetAllCommentsForRecipe(int recipeId)
        {
            var comments = await _commentService.GetAllCommentsForRecipe(recipeId);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentDto commentDto)
        {
            var userId = IdentityExtensions.GetUserId(User.Identity);
            commentDto.UserId = int.Parse(userId);
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
