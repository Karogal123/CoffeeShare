using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Core.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RecipeId { get; set; }
        public RecipeDto Recipe { get; set; }
        public string CommentBody { get; set; }
    }
}
