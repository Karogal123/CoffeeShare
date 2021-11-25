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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country {Id = 1, Name = "Brazil"},
                new Country {Id = 2, Name = "Vietnam"},
                new Country {Id = 3, Name = "Colombia"},
                new Country {Id = 4, Name = "Indonesia"},
                new Country {Id = 5, Name = "Costa Rica" },
                new Country {Id = 6, Name = "Ethiopia"},
                new Country {Id = 7, Name = "Honduras"},
                new Country {Id = 8, Name = "India"},
                new Country {Id = 9, Name = "Uganda"},
                new Country {Id = 10, Name = "Mexico"},
                new Country {Id = 11, Name = "Guatemala"},
                new Country {Id = 12, Name = "Peru"},
                new Country {Id = 13, Name = "China"},
                new Country { Id = 14, Name = "Kenya" },
                new Country { Id = 15, Name = "Papua New Guinea" },
                new Country { Id = 16, Name = "Madagascar" },
                new Country { Id = 17, Name = "Haiti" },
                new Country { Id = 18, Name = "Venezuela" },
                new Country { Id = 19, Name = "Rwanda" },
                new Country { Id = 20, Name = "Cuba" },
                new Country { Id = 21, Name = "Panama" },
                new Country { Id = 22, Name = "Bolivia" },
                new Country { Id = 23, Name = "Nigeria" },
                new Country { Id = 24, Name = "Zimbabwe" },
                new Country { Id = 25, Name = "Zambia" }
            );
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, Name = "Default", NormalizedName = "DEFAULT"},
                new UserRole { Id = 2, Name = "Admin", NormalizedName = "ADMIN"});
            base.OnModelCreating(modelBuilder);
        }
    }
}
