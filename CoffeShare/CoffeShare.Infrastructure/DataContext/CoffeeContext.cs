using CoffeeShare.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShare.Infrastructure.DataContext
{
    public class CoffeeContext : IdentityDbContext<User, UserRole, int>
    {
        public CoffeeContext(DbContextOptions<CoffeeContext> opt) : base(opt) { }

        public CoffeeContext()
        {
            
        }
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeScore> RecipeScores { get; set; }
        public DbSet<RecipeTag> RecipeTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
