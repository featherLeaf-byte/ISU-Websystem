using Microsoft.EntityFrameworkCore.Migrations;

namespace ISU_By_DBugSolutions.Migrations
{
    public partial class meetsche6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Creche_MeetingSchedule_MeetingScheduleID",
                table: "Creche");

            migrationBuilder.DropIndex(
                name: "IX_Creche_MeetingScheduleID",
                table: "Creche");

            migrationBuilder.DropColumn(
                name: "CrecheName",
                table: "MeetingSchedule");

            migrationBuilder.DropColumn(
                name: "MeetingScheduleID",
                table: "Creche");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "MeetingSchedule",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Scheduler",
                table: "MeetingSchedule",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "MeetingSchedule",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Venue",
                table: "MeetingSchedule",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Venue",
                table: "MeetingSchedule");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "MeetingSchedule",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Scheduler",
                table: "MeetingSchedule",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "MeetingSchedule",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "CrecheName",
                table: "MeetingSchedule",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeetingScheduleID",
                table: "Creche",
                type: "int",
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
    }
}
