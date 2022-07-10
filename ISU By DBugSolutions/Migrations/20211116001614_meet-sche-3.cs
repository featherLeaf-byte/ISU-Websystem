using Microsoft.EntityFrameworkCore.Migrations;

namespace ISU_By_DBugSolutions.Migrations
{
    public partial class meetsche3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeetingScheduleID",
                table: "Creche",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Creche_MeetingScheduleID",
                table: "Creche",
                column: "MeetingScheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Creche_MeetingSchedule_MeetingScheduleID",
                table: "Creche",
                column: "MeetingScheduleID",
                principalTable: "MeetingSchedule",
                principalColumn: "MeetingScheduleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Creche_MeetingSchedule_MeetingScheduleID",
                table: "Creche");

            migrationBuilder.DropIndex(
                name: "IX_Creche_MeetingScheduleID",
                table: "Creche");

            migrationBuilder.DropColumn(
                name: "MeetingScheduleID",
                table: "Creche");
        }
    }
}
