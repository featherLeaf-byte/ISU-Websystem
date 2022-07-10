using Microsoft.EntityFrameworkCore.Migrations;

namespace ISU_By_DBugSolutions.Migrations
{
    public partial class meetsche4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creche",
                table: "MeetingSchedule");

            migrationBuilder.AddColumn<string>(
                name: "CrecheName",
                table: "MeetingSchedule",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrecheName",
                table: "MeetingSchedule");

            migrationBuilder.AddColumn<string>(
                name: "Creche",
                table: "MeetingSchedule",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
