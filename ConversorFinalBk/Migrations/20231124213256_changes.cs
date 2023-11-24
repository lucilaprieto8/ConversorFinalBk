using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversorFinalBk.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subscription",
                columns: new[] { "Id", "MaxAttemps", "Name", "Price" },
                values: new object[] { 1, 10, "Free", 0 });

            migrationBuilder.InsertData(
                table: "Subscription",
                columns: new[] { "Id", "MaxAttemps", "Name", "Price" },
                values: new object[] { 2, 100, "Trial", 10 });

            migrationBuilder.InsertData(
                table: "Subscription",
                columns: new[] { "Id", "MaxAttemps", "Name", "Price" },
                values: new object[] { 3, 10000, "Pro", 30 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subscription",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
