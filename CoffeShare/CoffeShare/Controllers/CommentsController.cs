using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShare.Infrastructure.Services;

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
            throw new NotImplementedException();
        }
    }
}
