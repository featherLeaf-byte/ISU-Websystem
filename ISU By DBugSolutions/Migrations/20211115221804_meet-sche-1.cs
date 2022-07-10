using Microsoft.EntityFrameworkCore.Migrations;

namespace ISU_By_DBugSolutions.Migrations
{
    public partial class meetsche1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pupil_MeetingSchedule_MeetingScheduleID",
                table: "Pupil");

            migrationBuilder.DropIndex(
                name: "IX_Pupil_MeetingScheduleID",
                table: "Pupil");

            migrationBuilder.DropColumn(
                name: "MeetingScheduleID",
                table: "Pupil");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "MeetingSchedule");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "PictureBooks",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Synopsis",
                table: "PictureBooks",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "BookFileName",
                table: "PictureBooks",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "PictureBooks",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AddColumn<string>(
                name: "Creche",
                table: "MeetingSchedule",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Scheduler",
                table: "MeetingSchedule",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creche",
                table: "MeetingSchedule");

            migrationBuilder.DropColumn(
                name: "Scheduler",
                table: "MeetingSchedule");

            migrationBuilder.AddColumn<int>(
                name: "MeetingScheduleID",
                table: "Pupil",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "PictureBooks",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Synopsis",
                table: "PictureBooks",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BookFileName",
                table: "PictureBooks",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "PictureBooks",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "MeetingSchedule",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pupil_MeetingScheduleID",
                table: "Pupil",
                column: "MeetingScheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pupil_MeetingSchedule_MeetingScheduleID",
                table: "Pupil",
                column: "MeetingScheduleID",
                principalTable: "MeetingSchedule",
                principalColumn: "MeetingScheduleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
