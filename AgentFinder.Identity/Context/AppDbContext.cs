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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerGroup> CustomerGroups { get; set; }
        public DbSet<MenuOptions> MenuOptions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<MenuOptions>().ToTable("MenuOptions");

            modelBuilder.Entity<Customer>().ToTable("Customers");

            modelBuilder.Entity<CustomerGroup>().ToTable("CustomerGroups");
        }
    }
}
