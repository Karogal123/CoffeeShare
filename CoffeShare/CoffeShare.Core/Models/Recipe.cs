using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShare.Core.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RecipeBody { get; set; }
        public int UserId { get; set; }
        public IntendedUse IntendedUse { get; set; }
    }
}
