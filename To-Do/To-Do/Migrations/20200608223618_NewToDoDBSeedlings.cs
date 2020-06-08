using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace To_Do.Migrations
{
    public partial class NewToDoDBSeedlings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Dry Storage Inventory");

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Assignee", "Difficulty", "ExpectedCompletion", "Title" },
                values: new object[] { 3, "Betsy", 3, new DateTime(2020, 6, 11, 6, 5, 11, 0, DateTimeKind.Utc), "Cold Storage Inventory" });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Assignee", "Difficulty", "ExpectedCompletion", "Title" },
                values: new object[] { 2, "Brice", 4, new DateTime(2020, 6, 11, 6, 5, 11, 0, DateTimeKind.Utc), "Freezer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Store Inventory");
        }
    }
}
