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
