using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Prog7312_MunicipalityApp_ST10299399.Migrations
{
    /// <inheritdoc />
    public partial class InitialEventSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    EventDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    PostedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Category", "Description", "EventDate", "ImageUrl", "Location", "PostedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Environment", "Join us for a community cleanup event to keep our neighborhood beautiful.", new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/images/cleanup.jpg", "Central Park", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Community Cleanup" },
                    { 2, "Market", "Fresh produce and local goods available at the weekly farmers market.", new DateTime(2025, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/images/farmers_market.jpg", "Town Square", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Farmers Market" },
                    { 3, "Art", "Experience local art and live music in the park.", new DateTime(2025, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://example.com/images/art_in_park.jpg", "Riverside Park", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Art in the Park" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
