using Microsoft.EntityFrameworkCore;
using Prog7312_MunicipalityApp_ST10299399.Models;

namespace Prog7312_MunicipalityApp_ST10299399.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed initial data
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Title = "Community Cleanup",
                    Description = "Join us for a community cleanup event to keep our neighborhood beautiful.",
                    Category = "Environment",
                    Date = DateTime.Now.AddDays(10),
                    Location = "Central Park",
                    ImageUrl = "https://example.com/images/cleanup.jpg"
                },
                new Event
                {
                    Id = 2,
                    Title = "Farmers Market",
                    Description = "Fresh produce and local goods available at the weekly farmers market.",
                    Category = "Market",
                    Date = DateTime.Now.AddDays(5),
                    Location = "Town Square",
                    ImageUrl = "https://example.com/images/farmers_market.jpg"
                },
                new Event
                {
                    Id = 3,
                    Title = "Art in the Park",
                    Description = "Experience local art and live music in the park.",
                    Category = "Art",
                    Date = DateTime.Now.AddDays(15),
                    Location = "Riverside Park",
                    ImageUrl = "https://example.com/images/art_in_park.jpg"
                }
            );
        }
    }
}
