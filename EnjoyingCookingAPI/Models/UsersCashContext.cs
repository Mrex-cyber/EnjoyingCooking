using Microsoft.EntityFrameworkCore;

namespace EnjoyingCookingAPI.Models
{
    public class UsersCashContext : DbContext
    {
        
        public DbSet<Pocket> Pockets { get; set; } = null!;
        public IConfiguration? Configuration { get; }
        public UsersCashContext()
            : base()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            Database.EnsureCreated();
        }
        public UsersCashContext(DbContextOptions<CookingContext> context)
            : base(context)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(u => u.Pocket)
                .WithOne(p => p.User)
                .HasForeignKey("PocketId")
                .OnDelete(DeleteBehavior.Cascade);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("SecretCashingConnection"));
        }
    }
}
