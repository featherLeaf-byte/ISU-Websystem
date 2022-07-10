using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ISU_By_DBugSolutions.Migrations
{
    public partial class Init35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.AddColumn<int>(
                name: "MeetingScheduleID",
                table: "Pupil",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MeetingSchedule",
                columns: table => new
                {
                    MeetingScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingSchedule", x => x.MeetingScheduleID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pupil_MeetingSchedule_MeetingScheduleID",
                table: "Pupil");

            migrationBuilder.DropTable(
                name: "MeetingSchedule");

            migrationBuilder.DropIndex(
                name: "IX_Pupil_MeetingScheduleID",
                table: "Pupil");

            migrationBuilder.DropColumn(
                name: "MeetingScheduleID",
                table: "Pupil");

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    MeetingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingEnd = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MeetingStart = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.MeetingID);
                });
        }
    }
}
