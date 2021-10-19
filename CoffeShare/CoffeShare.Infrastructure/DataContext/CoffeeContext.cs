using CoffeeShare.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShare.Infrastructure.DataContext
{
    public class CoffeeContext : DbContext
    {
        public CoffeeContext(DbContextOptions<CoffeeContext> opt) : base(opt) { }

        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeScore> RecipeScores { get; set; }
        public DbSet<RecipeTag> RecipeTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Brazil"
                },
                new Country
                {
                    Id = 2,
                    Name = "Vietnam"
                },
                new Country
                {
                    Id = 3,
                    Name = "Colombia"
                },
                new Country
                {
                    Id = 4,
                    Name = "Indonesia"
                },
                new Country
                {
                    Id = 5,
                    Name = "Honduras"
                },
                new Country
                {
                    Id = 6,
                    Name = "Ethiopia"
                },
                new Country
                {
                    Id = 7,
                    Name = "Peru"
                },
                new Country
                {
                    Id = 8,
                    Name = "India"
                },
                new Country
                {
                    Id = 9,
                    Name = "Guatemala"
                },
                new Country
                {
                    Id = 10,
                    Name = "Uganda"
                }
            );
        }
    }
}
