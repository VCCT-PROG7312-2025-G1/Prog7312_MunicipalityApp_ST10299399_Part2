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
                    Description = "Join us for a community cleanup event to keep our neighborhood beautiful.",
                    Category = "Environment",
                    EventDate = today.AddDays(10),
                    Location = "Central Park",
                    ImageUrl = "https://example.com/images/cleanup.jpg"
                },
                new Event
                {
                    Id = 2,
                    Title = "Farmers Market",
                    Description = "Fresh produce and local goods available at the weekly farmers market.",
                    Category = "Market",
                    EventDate = today.AddDays(5),
                    Location = "Town Square",
                    ImageUrl = "https://example.com/images/farmers_market.jpg"
                },
                new Event
                {
                    Id = 3,
                    Title = "Art in the Park",
                    Description = "Experience local art and live music in the park.",
                    Category = "Art",
                    EventDate = today.AddDays(15),
                    Location = "Riverside Park",
                    ImageUrl = "https://example.com/images/art_in_park.jpg"
                }
            );
        }
    }
}
