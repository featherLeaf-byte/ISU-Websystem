using Microsoft.EntityFrameworkCore.Migrations;

namespace ISU_By_DBugSolutions.Migrations
{
    public partial class email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "HouseNo");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropTable(
                name: "Suburb");

            migrationBuilder.AlterColumn<string>(
                name: "SuburbName",
                table: "Pupil",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SuburbName",
                table: "ProvincialLiason",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Creche",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SuburbName",
                table: "Pupil",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SuburbName",
                table: "ProvincialLiason",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "Creche",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchTerm = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrecheID = table.Column<int>(type: "int", nullable: true),
                    ECDCManagerID = table.Column<int>(type: "int", nullable: true),
                    ECDCTeacherID = table.Column<int>(type: "int", nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    ProvincialLiasonID = table.Column<int>(type: "int", nullable: true),
                    PupilID = table.Column<int>(type: "int", nullable: true),
                    RegionalCoordinatorRegCoodID = table.Column<int>(type: "int", nullable: true),
                    SearchTerm = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_City_Creche_CrecheID",
                        column: x => x.CrecheID,
                        principalTable: "Creche",
                        principalColumn: "CrecheID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_City_ECDCManager_ECDCManagerID",
                        column: x => x.ECDCManagerID,
                        principalTable: "ECDCManager",
                        principalColumn: "ECDCManagerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_City_ECDCTeacher_ECDCTeacherID",
                        column: x => x.ECDCTeacherID,
                        principalTable: "ECDCTeacher",
                        principalColumn: "ECDCTeacherID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_City_Parent_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Parent",
                        principalColumn: "ParentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_City_ProvincialLiason_ProvincialLiasonID",
                        column: x => x.ProvincialLiasonID,
                        principalTable: "ProvincialLiason",
                        principalColumn: "ProvincialLiasonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_City_Pupil_PupilID",
                        column: x => x.PupilID,
                        principalTable: "Pupil",
                        principalColumn: "PupilID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_City_RegionalCoordinator_RegionalCoordinatorRegCoodID",
                        column: x => x.RegionalCoordinatorRegCoodID,
                        principalTable: "RegionalCoordinator",
                        principalColumn: "RegCoodID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HouseNo",
                columns: table => new
                {
                    HouseNoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrecheID = table.Column<int>(type: "int", nullable: true),
                    ECDCManagerID = table.Column<int>(type: "int", nullable: true),
                    ECDCTeacherID = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    ProvincialLiasonID = table.Column<int>(type: "int", nullable: true),
                    PupilID = table.Column<int>(type: "int", nullable: true),
                    RegionalCoordinatorRegCoodID = table.Column<int>(type: "int", nullable: true),
                    SearchTerm = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseNo", x => x.HouseNoID);
                    table.ForeignKey(
                        name: "FK_HouseNo_Creche_CrecheID",
                        column: x => x.CrecheID,
                        principalTable: "Creche",
                        principalColumn: "CrecheID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HouseNo_ECDCManager_ECDCManagerID",
                        column: x => x.ECDCManagerID,
                        principalTable: "ECDCManager",
                        principalColumn: "ECDCManagerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HouseNo_ECDCTeacher_ECDCTeacherID",
                        column: x => x.ECDCTeacherID,
                        principalTable: "ECDCTeacher",
                        principalColumn: "ECDCTeacherID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HouseNo_Parent_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Parent",
                        principalColumn: "ParentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HouseNo_ProvincialLiason_ProvincialLiasonID",
                        column: x => x.ProvincialLiasonID,
                        principalTable: "ProvincialLiason",
                        principalColumn: "ProvincialLiasonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HouseNo_Pupil_PupilID",
                        column: x => x.PupilID,
                        principalTable: "Pupil",
                        principalColumn: "PupilID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HouseNo_RegionalCoordinator_RegionalCoordinatorRegCoodID",
                        column: x => x.RegionalCoordinatorRegCoodID,
                        principalTable: "RegionalCoordinator",
                        principalColumn: "RegCoodID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    StreetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrecheID = table.Column<int>(type: "int", nullable: true),
                    ECDCManagerID = table.Column<int>(type: "int", nullable: true),
                    ECDCTeacherID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    ProvincialLiasonID = table.Column<int>(type: "int", nullable: true),
                    PupilID = table.Column<int>(type: "int", nullable: true),
                    RegionalCoordinatorRegCoodID = table.Column<int>(type: "int", nullable: true),
                    SearchTerm = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street", x => x.StreetID);
                    table.ForeignKey(
                        name: "FK_Street_Creche_CrecheID",
                        column: x => x.CrecheID,
                        principalTable: "Creche",
                        principalColumn: "CrecheID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Street_ECDCManager_ECDCManagerID",
                        column: x => x.ECDCManagerID,
                        principalTable: "ECDCManager",
                        principalColumn: "ECDCManagerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Street_ECDCTeacher_ECDCTeacherID",
                        column: x => x.ECDCTeacherID,
                        principalTable: "ECDCTeacher",
                        principalColumn: "ECDCTeacherID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Street_Parent_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Parent",
                        principalColumn: "ParentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Street_ProvincialLiason_ProvincialLiasonID",
                        column: x => x.ProvincialLiasonID,
                        principalTable: "ProvincialLiason",
                        principalColumn: "ProvincialLiasonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Street_Pupil_PupilID",
                        column: x => x.PupilID,
                        principalTable: "Pupil",
                        principalColumn: "PupilID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Street_RegionalCoordinator_RegionalCoordinatorRegCoodID",
                        column: x => x.RegionalCoordinatorRegCoodID,
                        principalTable: "RegionalCoordinator",
                        principalColumn: "RegCoodID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suburb",
                columns: table => new
                {
                    SuburbID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrecheID = table.Column<int>(type: "int", nullable: true),
                    ECDCManagerID = table.Column<int>(type: "int", nullable: true),
                    ECDCTeacherID = table.Column<int>(type: "int", nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    ProvincialLiasonID = table.Column<int>(type: "int", nullable: true),
                    PupilID = table.Column<int>(type: "int", nullable: true),
                    RegionalCoordinatorRegCoodID = table.Column<int>(type: "int", nullable: true),
                    SearchTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuburbName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suburb", x => x.SuburbID);
                    table.ForeignKey(
                        name: "FK_Suburb_Creche_CrecheID",
                        column: x => x.CrecheID,
                        principalTable: "Creche",
                        principalColumn: "CrecheID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suburb_ECDCManager_ECDCManagerID",
                        column: x => x.ECDCManagerID,
                        principalTable: "ECDCManager",
                        principalColumn: "ECDCManagerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suburb_ECDCTeacher_ECDCTeacherID",
                        column: x => x.ECDCTeacherID,
                        principalTable: "ECDCTeacher",
                        principalColumn: "ECDCTeacherID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suburb_Parent_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Parent",
                        principalColumn: "ParentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suburb_ProvincialLiason_ProvincialLiasonID",
                        column: x => x.ProvincialLiasonID,
                        principalTable: "ProvincialLiason",
                        principalColumn: "ProvincialLiasonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suburb_Pupil_PupilID",
                        column: x => x.PupilID,
                        principalTable: "Pupil",
                        principalColumn: "PupilID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suburb_RegionalCoordinator_RegionalCoordinatorRegCoodID",
                        column: x => x.RegionalCoordinatorRegCoodID,
                        principalTable: "RegionalCoordinator",
                        principalColumn: "RegCoodID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CrecheID",
                table: "City",
                column: "CrecheID");

            migrationBuilder.CreateIndex(
                name: "IX_City_ECDCManagerID",
                table: "City",
                column: "ECDCManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_City_ECDCTeacherID",
                table: "City",
                column: "ECDCTeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_City_ParentID",
                table: "City",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvincialLiasonID",
                table: "City",
                column: "ProvincialLiasonID");

            migrationBuilder.CreateIndex(
                name: "IX_City_PupilID",
                table: "City",
                column: "PupilID");

            migrationBuilder.CreateIndex(
                name: "IX_City_RegionalCoordinatorRegCoodID",
                table: "City",
                column: "RegionalCoordinatorRegCoodID");

            migrationBuilder.CreateIndex(
                name: "IX_HouseNo_CrecheID",
                table: "HouseNo",
                column: "CrecheID");

            migrationBuilder.CreateIndex(
                name: "IX_HouseNo_ECDCManagerID",
                table: "HouseNo",
                column: "ECDCManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_HouseNo_ECDCTeacherID",
                table: "HouseNo",
                column: "ECDCTeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_HouseNo_ParentID",
                table: "HouseNo",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_HouseNo_ProvincialLiasonID",
                table: "HouseNo",
                column: "ProvincialLiasonID");

            migrationBuilder.CreateIndex(
                name: "IX_HouseNo_PupilID",
                table: "HouseNo",
                column: "PupilID");

            migrationBuilder.CreateIndex(
                name: "IX_HouseNo_RegionalCoordinatorRegCoodID",
                table: "HouseNo",
                column: "RegionalCoordinatorRegCoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Street_CrecheID",
                table: "Street",
                column: "CrecheID");

            migrationBuilder.CreateIndex(
                name: "IX_Street_ECDCManagerID",
                table: "Street",
                column: "ECDCManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Street_ECDCTeacherID",
                table: "Street",
                column: "ECDCTeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Street_ParentID",
                table: "Street",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Street_ProvincialLiasonID",
                table: "Street",
                column: "ProvincialLiasonID");

            migrationBuilder.CreateIndex(
                name: "IX_Street_PupilID",
                table: "Street",
                column: "PupilID");

            migrationBuilder.CreateIndex(
                name: "IX_Street_RegionalCoordinatorRegCoodID",
                table: "Street",
                column: "RegionalCoordinatorRegCoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Suburb_CrecheID",
                table: "Suburb",
                column: "CrecheID");

            migrationBuilder.CreateIndex(
                name: "IX_Suburb_ECDCManagerID",
                table: "Suburb",
                column: "ECDCManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Suburb_ECDCTeacherID",
                table: "Suburb",
                column: "ECDCTeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Suburb_ParentID",
                table: "Suburb",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Suburb_ProvincialLiasonID",
                table: "Suburb",
                column: "ProvincialLiasonID");

            migrationBuilder.CreateIndex(
                name: "IX_Suburb_PupilID",
                table: "Suburb",
                column: "PupilID");

            migrationBuilder.CreateIndex(
                name: "IX_Suburb_RegionalCoordinatorRegCoodID",
                table: "Suburb",
                column: "RegionalCoordinatorRegCoodID");
        }
    }
}
