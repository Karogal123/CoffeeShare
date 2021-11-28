using CoffeeShare.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShare.Core.Dto;
using CoffeeShare.Infrastructure.DataContext;
using CoffeeShare.Infrastructure.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace CoffeeShare.Controllers
{
    [ApiController]
    [Route("Comments")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly CoffeeContext _context;

        public CommentsController(ICommentService commentService, CoffeeContext context)
        {
            _commentService = commentService;
            _context = context;
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
            var claims = User.Claims.FirstOrDefault();
            var user = _context.Users.SingleOrDefault(x => x.Email == claims.Value);
            commentDto.UserId = user.Id;
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
