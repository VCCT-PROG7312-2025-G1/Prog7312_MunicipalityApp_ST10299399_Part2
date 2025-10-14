using Microsoft.EntityFrameworkCore;
using Prog7312_MunicipalityApp_ST10299399.Models;

namespace Prog7312_MunicipalityApp_ST10299399.Data
{
    // Database context for the application
    public class AppDbContext : DbContext
    {
        // Constructor accepting DbContext options
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // DbSet representing the Events table
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }

        // Seed initial data into the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DateTime today = DateTime.Parse("2025-10-13");
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Title = "Community Cleanup",
                    Description = "Come help us keep our town clean!!!",
                    Category = "Environment",
                    EventDate = today.AddDays(10),
                    Location = "Vyeboom",
                },
                new Event
                {
                    Id = 2,
                    Title = "Church Bazaar",
                    Description = "Come and join us for a lovely Church Bazaar to support the Church",
                    Category = "Market",
                    EventDate = today.AddDays(5),
                    Location = "Vyeboom Church",
                },
                new Event
                {
                    Id = 3,
                    Title = "Park Run",
                    Description = "Come and support our first ever park run!",
                    Category = "Sport",
                    EventDate = today.AddDays(15),
                    Location = "Vyeboom Park",
                }
            );

            // Seed an admin user 
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "Admin@123", 
                    Role = "Admin"
                }
            );
        }
    }
}
