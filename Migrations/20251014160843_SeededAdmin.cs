using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prog7312_MunicipalityApp_ST10299399.Migrations
{
    /// <inheritdoc />
    public partial class SeededAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Location" },
                values: new object[] { "Come help us keep our town clean!!!", null, "Vyeboom" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Location", "Title" },
                values: new object[] { "Come and join us for a lovely Church Bazaar to support the Church", null, "Vyeboom Church", "Church Bazaar" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Description", "ImageUrl", "Location", "Title" },
                values: new object[] { "Sport", "Come and support our first ever park run!", null, "Vyeboom Park", "Park Run" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[] { 1, "Admin@123", "Admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Location" },
                values: new object[] { "Join us for a community cleanup event to keep our neighborhood beautiful.", "https://example.com/images/cleanup.jpg", "Central Park" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Location", "Title" },
                values: new object[] { "Fresh produce and local goods available at the weekly farmers market.", "https://example.com/images/farmers_market.jpg", "Town Square", "Farmers Market" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Description", "ImageUrl", "Location", "Title" },
                values: new object[] { "Art", "Experience local art and live music in the park.", "https://example.com/images/art_in_park.jpg", "Riverside Park", "Art in the Park" });
        }
    }
}
