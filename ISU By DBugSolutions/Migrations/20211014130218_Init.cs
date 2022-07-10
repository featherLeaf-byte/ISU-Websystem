using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ISU_By_DBugSolutions.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    MaritalStatus = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "EatingSchedule",
                columns: table => new
                {
                    EatingSchedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrecheName = table.Column<string>(nullable: false),
                    MealName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EatingSchedule", x => x.EatingSchedID);
                });

            migrationBuilder.CreateTable(
                name: "ECDCManager",
                columns: table => new
                {
                    ECDCManagerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    ContactNo = table.Column<string>(nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    houseNo = table.Column<string>(nullable: false),
                    streetName = table.Column<string>(nullable: false),
                    SuburbName = table.Column<string>(nullable: false),
                    CityName = table.Column<string>(nullable: false),
                    ProvinceName = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECDCManager", x => x.ECDCManagerID);
                });

            migrationBuilder.CreateTable(
                name: "ECDCTeacher",
                columns: table => new
                {
                    ECDCTeacherID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    ContactNo = table.Column<string>(nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    houseNo = table.Column<string>(nullable: false),
                    streetName = table.Column<string>(nullable: false),
                    SuburbName = table.Column<string>(nullable: false),
                    CityName = table.Column<string>(nullable: false),
                    ProvinceName = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECDCTeacher", x => x.ECDCTeacherID);
                });

            migrationBuilder.CreateTable(
                name: "Enquiry",
                columns: table => new
                {
                    EnquiryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Details = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquiry", x => x.EnquiryID);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                columns: table => new
                {
                    MedHistID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PupilName = table.Column<string>(nullable: false),
                    PupilSurname = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DiseaseName = table.Column<string>(nullable: false),
                    SurgeryName = table.Column<string>(nullable: false),
                    AllergyName = table.Column<string>(nullable: false),
                    DoctorName = table.Column<string>(nullable: false),
                    MedicationName = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory", x => x.MedHistID);
                });

            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    ParentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    ContactNo = table.Column<string>(nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    houseNo = table.Column<string>(nullable: false),
                    streetName = table.Column<string>(nullable: false),
                    SuburbName = table.Column<string>(nullable: false),
                    CityName = table.Column<string>(nullable: false),
                    ProvinceName = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.ParentID);
                });

            migrationBuilder.CreateTable(
                name: "ProvincialLiason",
                columns: table => new
                {
                    ProvincialLiasonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    ContactNo = table.Column<string>(nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    houseNo = table.Column<string>(nullable: false),
                    streetName = table.Column<string>(nullable: false),
                    SuburbName = table.Column<string>(nullable: false),
                    CityName = table.Column<string>(nullable: false),
                    ProvinceName = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvincialLiason", x => x.ProvincialLiasonID);
                });

            migrationBuilder.CreateTable(
                name: "Pupil",
                columns: table => new
                {
                    PupilID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    ContactNo = table.Column<string>(nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    houseNo = table.Column<string>(nullable: false),
                    streetName = table.Column<string>(nullable: false),
                    SuburbName = table.Column<string>(nullable: false),
                    CityName = table.Column<string>(nullable: false),
                    ProvinceName = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupil", x => x.PupilID);
                });

            migrationBuilder.CreateTable(
                name: "RegionalCoordinator",
                columns: table => new
                {
                    RegCoodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    ContactNo = table.Column<string>(nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    houseNo = table.Column<string>(nullable: false),
                    streetName = table.Column<string>(nullable: false),
                    SuburbName = table.Column<string>(nullable: false),
                    CityName = table.Column<string>(nullable: false),
                    ProvinceName = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionalCoordinator", x => x.RegCoodID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Creche",
                columns: table => new
                {
                    CrecheID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    HouseNo = table.Column<string>(nullable: false),
                    StreetName = table.Column<string>(nullable: false),
                    SuburbName = table.Column<string>(nullable: false),
                    CityName = table.Column<string>(nullable: false),
                    ProvinceName = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true),
                    EatingScheduleEatingSchedID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creche", x => x.CrecheID);
                    table.ForeignKey(
                        name: "FK_Creche_EatingSchedule_EatingScheduleEatingSchedID",
                        column: x => x.EatingScheduleEatingSchedID,
                        principalTable: "EatingSchedule",
                        principalColumn: "EatingSchedID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    MealID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    EatingScheduleEatingSchedID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.MealID);
                    table.ForeignKey(
                        name: "FK_Meal_EatingSchedule_EatingScheduleEatingSchedID",
                        column: x => x.EatingScheduleEatingSchedID,
                        principalTable: "EatingSchedule",
                        principalColumn: "EatingSchedID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Allergy",
                columns: table => new
                {
                    AllergyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergyName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true),
                    MedicalHistoryMedHistID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergy", x => x.AllergyID);
                    table.ForeignKey(
                        name: "FK_Allergy_MedicalHistory_MedicalHistoryMedHistID",
                        column: x => x.MedicalHistoryMedHistID,
                        principalTable: "MedicalHistory",
                        principalColumn: "MedHistID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Disease",
                columns: table => new
                {
                    DiseaseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true),
                    MedicalHistoryMedHistID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease", x => x.DiseaseID);
                    table.ForeignKey(
                        name: "FK_Disease_MedicalHistory_MedicalHistoryMedHistID",
                        column: x => x.MedicalHistoryMedHistID,
                        principalTable: "MedicalHistory",
                        principalColumn: "MedHistID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    ContactNo = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true),
                    MedicalHistoryMedHistID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_Doctor_MedicalHistory_MedicalHistoryMedHistID",
                        column: x => x.MedicalHistoryMedHistID,
                        principalTable: "MedicalHistory",
                        principalColumn: "MedHistID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    MedicationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true),
                    MedicalHistoryMedHistID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.MedicationID);
                    table.ForeignKey(
                        name: "FK_Medication_MedicalHistory_MedicalHistoryMedHistID",
                        column: x => x.MedicalHistoryMedHistID,
                        principalTable: "MedicalHistory",
                        principalColumn: "MedHistID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Surgery",
                columns: table => new
                {
                    SurgeryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurgeryName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true),
                    MedicalHistoryMedHistID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surgery", x => x.SurgeryID);
                    table.ForeignKey(
                        name: "FK_Surgery_MedicalHistory_MedicalHistoryMedHistID",
                        column: x => x.MedicalHistoryMedHistID,
                        principalTable: "MedicalHistory",
                        principalColumn: "MedHistID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true),
                    CrecheID = table.Column<int>(nullable: true),
                    ECDCManagerID = table.Column<int>(nullable: true),
                    ECDCTeacherID = table.Column<int>(nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    ProvincialLiasonID = table.Column<int>(nullable: true),
                    PupilID = table.Column<int>(nullable: true),
                    RegionalCoordinatorRegCoodID = table.Column<int>(nullable: true)
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
                    HouseNoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true),
                    CrecheID = table.Column<int>(nullable: true),
                    ECDCManagerID = table.Column<int>(nullable: true),
                    ECDCTeacherID = table.Column<int>(nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    ProvincialLiasonID = table.Column<int>(nullable: true),
                    PupilID = table.Column<int>(nullable: true),
                    RegionalCoordinatorRegCoodID = table.Column<int>(nullable: true)
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
                name: "Province",
                columns: table => new
                {
                    ProvinceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true),
                    CrecheID = table.Column<int>(nullable: true),
                    ECDCManagerID = table.Column<int>(nullable: true),
                    ECDCTeacherID = table.Column<int>(nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    ProvincialLiasonID = table.Column<int>(nullable: true),
                    PupilID = table.Column<int>(nullable: true),
                    RegionalCoordinatorRegCoodID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceID);
                    table.ForeignKey(
                        name: "FK_Province_Creche_CrecheID",
                        column: x => x.CrecheID,
                        principalTable: "Creche",
                        principalColumn: "CrecheID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Province_ECDCManager_ECDCManagerID",
                        column: x => x.ECDCManagerID,
                        principalTable: "ECDCManager",
                        principalColumn: "ECDCManagerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Province_ECDCTeacher_ECDCTeacherID",
                        column: x => x.ECDCTeacherID,
                        principalTable: "ECDCTeacher",
                        principalColumn: "ECDCTeacherID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Province_Parent_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Parent",
                        principalColumn: "ParentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Province_ProvincialLiason_ProvincialLiasonID",
                        column: x => x.ProvincialLiasonID,
                        principalTable: "ProvincialLiason",
                        principalColumn: "ProvincialLiasonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Province_Pupil_PupilID",
                        column: x => x.PupilID,
                        principalTable: "Pupil",
                        principalColumn: "PupilID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Province_RegionalCoordinator_RegionalCoordinatorRegCoodID",
                        column: x => x.RegionalCoordinatorRegCoodID,
                        principalTable: "RegionalCoordinator",
                        principalColumn: "RegCoodID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    StreetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true),
                    CrecheID = table.Column<int>(nullable: true),
                    ECDCManagerID = table.Column<int>(nullable: true),
                    ECDCTeacherID = table.Column<int>(nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    ProvincialLiasonID = table.Column<int>(nullable: true),
                    PupilID = table.Column<int>(nullable: true),
                    RegionalCoordinatorRegCoodID = table.Column<int>(nullable: true)
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
                    SuburbID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuburbName = table.Column<string>(nullable: false),
                    SearchTerm = table.Column<string>(nullable: true),
                    CrecheID = table.Column<int>(nullable: true),
                    ECDCManagerID = table.Column<int>(nullable: true),
                    ECDCTeacherID = table.Column<int>(nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    ProvincialLiasonID = table.Column<int>(nullable: true),
                    PupilID = table.Column<int>(nullable: true),
                    RegionalCoordinatorRegCoodID = table.Column<int>(nullable: true)
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
                name: "IX_Allergy_MedicalHistoryMedHistID",
                table: "Allergy",
                column: "MedicalHistoryMedHistID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Creche_EatingScheduleEatingSchedID",
                table: "Creche",
                column: "EatingScheduleEatingSchedID");

            migrationBuilder.CreateIndex(
                name: "IX_Disease_MedicalHistoryMedHistID",
                table: "Disease",
                column: "MedicalHistoryMedHistID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_MedicalHistoryMedHistID",
                table: "Doctor",
                column: "MedicalHistoryMedHistID");

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
                name: "IX_Meal_EatingScheduleEatingSchedID",
                table: "Meal",
                column: "EatingScheduleEatingSchedID");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_MedicalHistoryMedHistID",
                table: "Medication",
                column: "MedicalHistoryMedHistID");

            migrationBuilder.CreateIndex(
                name: "IX_Province_CrecheID",
                table: "Province",
                column: "CrecheID");

            migrationBuilder.CreateIndex(
                name: "IX_Province_ECDCManagerID",
                table: "Province",
                column: "ECDCManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Province_ECDCTeacherID",
                table: "Province",
                column: "ECDCTeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Province_ParentID",
                table: "Province",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Province_ProvincialLiasonID",
                table: "Province",
                column: "ProvincialLiasonID");

            migrationBuilder.CreateIndex(
                name: "IX_Province_PupilID",
                table: "Province",
                column: "PupilID");

            migrationBuilder.CreateIndex(
                name: "IX_Province_RegionalCoordinatorRegCoodID",
                table: "Province",
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

            migrationBuilder.CreateIndex(
                name: "IX_Surgery_MedicalHistoryMedHistID",
                table: "Surgery",
                column: "MedicalHistoryMedHistID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergy");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Disease");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Enquiry");

            migrationBuilder.DropTable(
                name: "HouseNo");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropTable(
                name: "Suburb");

            migrationBuilder.DropTable(
                name: "Surgery");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Creche");

            migrationBuilder.DropTable(
                name: "ECDCManager");

            migrationBuilder.DropTable(
                name: "ECDCTeacher");

            migrationBuilder.DropTable(
                name: "Parent");

            migrationBuilder.DropTable(
                name: "ProvincialLiason");

            migrationBuilder.DropTable(
                name: "Pupil");

            migrationBuilder.DropTable(
                name: "RegionalCoordinator");

            migrationBuilder.DropTable(
                name: "MedicalHistory");

            migrationBuilder.DropTable(
                name: "EatingSchedule");
        }
    }
}
