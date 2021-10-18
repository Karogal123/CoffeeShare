using CoffeeShare.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShare.Core.Dto
{
    public class RecipeScoreDto
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public RecipeDto Recipe { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Score { get; set; }
    }
}
