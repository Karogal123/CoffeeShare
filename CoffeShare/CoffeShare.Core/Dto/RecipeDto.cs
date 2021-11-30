using CoffeeShare.Core.Models;

namespace CoffeeShare.Core.Dto
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RecipeBody { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IntendedUse IntendedUse { get; set; }
        public int CoffeeId { get; set; }
        public Coffee Coffee { get; set; }
        public int CoffeeAmount { get; set; }
        public GrindLevel GrindLevel { get; set; }
        public int WaterAmount { get; set; }
        public int WaterTemperature { get; set; }
    }
}
