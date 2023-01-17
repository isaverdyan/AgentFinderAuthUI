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
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerGroup> CustomerGroups { get; set; }
        public DbSet<CustomerGroupUsers> CustomerGroupsUsers { get; set; }
        public DbSet<MenuOptions> MenuOptions { get; set; }
        public DbSet<OfferMessage> OfferMessages { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<AgentInterestsLocation> AgentsInterestsLocations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<MenuOptions>().ToTable("MenuOptions");

            modelBuilder.Entity<Customer>().ToTable("Customers");

            modelBuilder.Entity<CustomerGroup>().ToTable("CustomerGroups");

            modelBuilder.Entity<CustomerGroupUsers>().ToTable("CustomerGroupUsers");

            modelBuilder.Entity<OfferMessage>().ToTable("OfferMessages");
        }
    }
}
