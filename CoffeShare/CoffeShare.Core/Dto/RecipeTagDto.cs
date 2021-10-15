using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShare.Core.Dto
{
    public class RecipeTagDto
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public RecipeDto Recipe { get; set; }
        public int TagId { get; set; }
        public TagDto Tag { get; set; }
    }
}
