using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ISU_By_DBugSolutions.Migrations
{
    public partial class spreadsheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spreadsheets",
                columns: table => new
                {
                    SpreadsheetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SheetName = table.Column<string>(nullable: false),
                    DateOfUpload = table.Column<DateTime>(nullable: false),
                    SpreadsheetName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spreadsheets", x => x.SpreadsheetID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spreadsheets");
        }
    }
}
