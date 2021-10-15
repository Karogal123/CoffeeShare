using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Core.Dto
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RecipeBody { get; set; }
        public int UserId { get; set; }
        public IntendedUse IntendedUse { get; set; }
    }
}
