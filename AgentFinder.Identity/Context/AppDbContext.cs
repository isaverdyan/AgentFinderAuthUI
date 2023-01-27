using AgentFinder.Identity.Models;
using AgentFinder.Identity.Models.Provider;
using Microsoft.EntityFrameworkCore;

namespace AgentFinder.Identity.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<Agent> Agents { get; set; }
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
        public DbSet<AgentCustomer> AgentCustomers { get; set; }
        public DbSet<CustomerNotification> CustomerNotifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserId)
                .IsUnique();

            modelBuilder.Entity<Agent>().ToTable("Agents");

            modelBuilder.Entity<MenuOptions>().ToTable("MenuOptions");

            modelBuilder.Entity<Customer>().ToTable("Customers");

            modelBuilder.Entity<CustomerGroup>().ToTable("CustomerGroups");

            modelBuilder.Entity<CustomerGroupUsers>().ToTable("CustomerGroupUsers");

            modelBuilder.Entity<OfferMessage>().ToTable("OfferMessages");

            modelBuilder.Entity<AgentCustomer>().ToTable("AgentCustomers");

            modelBuilder.Entity<CustomerNotification>().ToTable("CustomerNotifications");
        }
    }
}
