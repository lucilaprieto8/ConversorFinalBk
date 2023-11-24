using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversorFinalBk.Migrations
{
    public partial class okentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversion_User_IdUser",
                table: "Conversion");

            migrationBuilder.DropIndex(
                name: "IX_Conversion_IdUser",
                table: "Conversion");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Conversion");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Conversion",
                newName: "FirstTry");

            migrationBuilder.CreateTable(
                name: "ConversionHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CurrencyFrom = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrencyTo = table.Column<int>(type: "INTEGER", nullable: false),
                    AmountInput = table.Column<int>(type: "INTEGER", nullable: false),
                    AmountOutput = table.Column<int>(type: "INTEGER", nullable: false),
                    ConversionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConversionHistory_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConversionHistory_IdUser",
                table: "ConversionHistory",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversionHistory");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "User",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "FirstTry",
                table: "Conversion",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Conversion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Conversion_IdUser",
                table: "Conversion",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversion_User_IdUser",
                table: "Conversion",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
