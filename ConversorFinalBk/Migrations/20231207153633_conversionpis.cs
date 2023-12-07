using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversorFinalBk.Migrations
{
    public partial class conversionpis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Conversion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Conversion");
        }
    }
}
