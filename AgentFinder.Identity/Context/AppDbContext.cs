using AgentFinder.Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace AgentFinder.Identity.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<MenuOptions> MenuOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<MenuOptions>().ToTable("MenuOptions");
        }
    }
}
