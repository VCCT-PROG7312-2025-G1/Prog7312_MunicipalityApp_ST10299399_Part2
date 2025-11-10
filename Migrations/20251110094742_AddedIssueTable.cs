using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prog7312_MunicipalityApp_ST10299399.Migrations
{
    /// <inheritdoc />
    public partial class AddedIssueTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    issueType = table.Column<string>(type: "TEXT", nullable: false),
                    issueDescription = table.Column<string>(type: "TEXT", nullable: false),
                    issueStatus = table.Column<string>(type: "TEXT", nullable: false),
                    issueLocation = table.Column<string>(type: "TEXT", nullable: false),
                    issueImage = table.Column<string>(type: "TEXT", nullable: true),
                    issueDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issues");
        }
    }
}
