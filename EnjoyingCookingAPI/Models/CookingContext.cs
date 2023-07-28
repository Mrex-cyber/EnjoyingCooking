using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace EnjoyingCookingAPI.Models
{
    public class CookingContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<CookingRecipe> Recipes { get; set; } = null!;

        public IConfiguration Configuration { get; }
        public CookingContext()
            : base()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public CookingContext(DbContextOptions<CookingContext> context)
        : base(context)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(u => u.Recipes);

            builder.Entity<User>()
                .HasOne(u => u.Pocket)
                .WithOne(p => p.User)
                .HasForeignKey("Pocket")
                .OnDelete(DeleteBehavior.Cascade);

            var cookings = new List<CookingRecipe>()
                {
                    new CookingRecipe("First", "Light", 250, 15),
                    new CookingRecipe("Second", "Medium", 250, 123),
                    new CookingRecipe("Third", "Light", 250, 105),
                    new CookingRecipe("Fourth", "Hard", 2500, 5),
                    new CookingRecipe("Fifth", "Medium", 250, 30),
                };

            builder.Entity<CookingRecipe>().HasData(cookings);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("CommonConnection"));
        }
    }
}
