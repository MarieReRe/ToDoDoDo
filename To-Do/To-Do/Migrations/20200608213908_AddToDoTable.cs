using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace To_Do.Migrations
{
    public partial class AddToDoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    ExpectedCompletion = table.Column<DateTime>(nullable: true),
                    Assignee = table.Column<string>(nullable: true),
                    Difficulty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Assignee", "Difficulty", "ExpectedCompletion", "Title" },
                values: new object[] { 1, "Marie", 3, new DateTime(2020, 6, 10, 6, 5, 12, 0, DateTimeKind.Utc), "Store Inventory" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");
        }
    }
}
