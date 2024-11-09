using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRIS.Conecta.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Geodata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicData_Program_ProgramId",
                table: "AcademicData");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalData_City_CityResidenceId",
                table: "PersonalData");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalData_State_BornStateId",
                table: "PersonalData");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDatas_Cities_BornCityId",
                table: "PersonalData");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDatas_States_ResidenceStateId",
                table: "PersonalData");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_RequestTypes_RequestTypeId",
                table: "Tickets");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_State_TempId",
                table: "State");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_State_TempId1",
                table: "State");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RequestType_TempId",
                table: "RequestType");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Program_TempId",
                table: "Program");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Country_TempId",
                table: "Country");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_City_TempId",
                table: "City");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_City_TempId1",
                table: "City");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "states");

            migrationBuilder.RenameTable(
                name: "RequestType",
                newName: "RequestTypes");

            migrationBuilder.RenameTable(
                name: "Program",
                newName: "Programs");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameColumn(
                name: "TempId1",
                table: "states",
                newName: "country_id");

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "states",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "RequestTypes",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "Programs",
                newName: "ProgramType");

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "Countries",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TempId1",
                table: "Cities",
                newName: "state_id");

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "Cities",
                newName: "country_id");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "states",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "country_code",
                table: "states",
                type: "nchar(2)",
                fixedLength: true,
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "states",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fips_code",
                table: "states",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "flag",
                table: "states",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "iso2",
                table: "states",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "latitude",
                table: "states",
                type: "decimal(10,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "longitude",
                table: "states",
                type: "decimal(11,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "states",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "states",
                type: "nvarchar(191)",
                maxLength: 191,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "states",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "wikiDataId",
                table: "states",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RequestTypes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RequestTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "RequestTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "RequestTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "RequestTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "RequestTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestName",
                table: "RequestTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Programs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Programs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Programs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Programs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Programs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Programs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProgramName",
                table: "Programs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Countries",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "capital",
                table: "Countries",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Countries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "currency",
                table: "Countries",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "currency_name",
                table: "Countries",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "currency_symbol",
                table: "Countries",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "emoji",
                table: "Countries",
                type: "nvarchar(191)",
                maxLength: 191,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "emojiU",
                table: "Countries",
                type: "nvarchar(191)",
                maxLength: 191,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "flag",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "iso2",
                table: "Countries",
                type: "nchar(2)",
                fixedLength: true,
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "iso3",
                table: "Countries",
                type: "nchar(3)",
                fixedLength: true,
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "latitude",
                table: "Countries",
                type: "decimal(10,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "longitude",
                table: "Countries",
                type: "decimal(11,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Countries",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nationality",
                table: "Countries",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "native",
                table: "Countries",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "numeric_code",
                table: "Countries",
                type: "nchar(3)",
                fixedLength: true,
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phonecode",
                table: "Countries",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "region",
                table: "Countries",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "region_id",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "subregion",
                table: "Countries",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "subregion_id",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "timezones",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tld",
                table: "Countries",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "translations",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "wikiDataId",
                table: "Countries",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "country_code",
                table: "Cities",
                type: "nchar(2)",
                fixedLength: true,
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "country_name",
                table: "Cities",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2014, 1, 1, 12, 1, 1, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "flag",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<decimal>(
                name: "latitude",
                table: "Cities",
                type: "decimal(10,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "longitude",
                table: "Cities",
                type: "decimal(11,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Cities",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "state_code",
                table: "Cities",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "state_name",
                table: "Cities",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "wikiDataId",
                table: "Cities",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__states__3213E83F220489F8",
                table: "states",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestTypes",
                table: "RequestTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programs",
                table: "Programs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Countrie__3213E83FA74F3AF0",
                table: "Countries",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Cities__3213E83FCFF12A69",
                table: "Cities",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemplateResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RequestTypeId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateResponses_RequestsType_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_states_country_id",
                table: "states",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_RequestTypeId",
                table: "RequestTypes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestTypes_DepartmentId",
                table: "RequestTypes",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestTypes_DepartmentId_Name",
                table: "RequestTypes",
                column: "RequestName");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_DepartmentId",
                table: "Programs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_Id",
                table: "Programs",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programs_ProgramName",
                table: "Programs",
                column: "ProgramName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programs_ProgramType",
                table: "Programs",
                column: "ProgramType");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_country_id",
                table: "Cities",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_state_id",
                table: "Cities",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentName",
                table: "Departments",
                column: "Department",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyId_Name",
                table: "Departments",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Id",
                table: "Departments",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_Name",
                table: "Faculties",
                column: "FacultyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TemplateResponses_Id",
                table: "TemplateResponses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TemplateResponses_RequestTypeId",
                table: "TemplateResponses",
                column: "RequestTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicData_Programs_ProgramId",
                table: "AcademicData",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cities_countries",
                table: "Cities",
                column: "country_id",
                principalTable: "Countries",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_cities_states",
                table: "Cities",
                column: "state_id",
                principalTable: "states",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalData_Cities_CityResidenceId",
                table: "PersonalData",
                column: "CityResidenceId",
                principalTable: "Cities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalData_states_BornStateId",
                table: "PersonalData",
                column: "BornStateId",
                principalTable: "states",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDatas_Cities_BornCityId",
                table: "PersonalData",
                column: "BornCityId",
                principalTable: "Cities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDatas_States_ResidenceStateId",
                table: "PersonalData",
                column: "ResidenceStateId",
                principalTable: "states",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Programs_Deparments_DepartmentId",
                table: "Programs",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestTypes_Departments_DepartmentId",
                table: "RequestTypes",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_states_countries",
                table: "states",
                column: "country_id",
                principalTable: "Countries",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_RequestTypes_RequestTypeId",
                table: "Tickets",
                column: "RequestTypeId",
                principalTable: "RequestTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicData_Programs_ProgramId",
                table: "AcademicData");

            migrationBuilder.DropForeignKey(
                name: "FK_cities_countries",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_cities_states",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalData_Cities_CityResidenceId",
                table: "PersonalData");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalData_states_BornStateId",
                table: "PersonalData");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDatas_Cities_BornCityId",
                table: "PersonalData");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDatas_States_ResidenceStateId",
                table: "PersonalData");

            migrationBuilder.DropForeignKey(
                name: "FK_Programs_Deparments_DepartmentId",
                table: "Programs");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestTypes_Departments_DepartmentId",
                table: "RequestTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_states_countries",
                table: "states");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_RequestTypes_RequestTypeId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "TemplateResponses");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropPrimaryKey(
                name: "PK__states__3213E83F220489F8",
                table: "states");

            migrationBuilder.DropIndex(
                name: "IX_states_country_id",
                table: "states");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestTypes",
                table: "RequestTypes");

            migrationBuilder.DropIndex(
                name: "IX_RequestTypeId",
                table: "RequestTypes");

            migrationBuilder.DropIndex(
                name: "IX_RequestTypes_DepartmentId",
                table: "RequestTypes");

            migrationBuilder.DropIndex(
                name: "IX_RequestTypes_DepartmentId_Name",
                table: "RequestTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Programs",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_DepartmentId",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_Id",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_ProgramName",
                table: "Programs");

            migrationBuilder.DropIndex(
                name: "IX_Programs_ProgramType",
                table: "Programs");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Countrie__3213E83FA74F3AF0",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Cities__3213E83FCFF12A69",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_country_id",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_state_id",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "country_code",
                table: "states");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "states");

            migrationBuilder.DropColumn(
                name: "fips_code",
                table: "states");

            migrationBuilder.DropColumn(
                name: "flag",
                table: "states");

            migrationBuilder.DropColumn(
                name: "iso2",
                table: "states");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "states");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "states");

            migrationBuilder.DropColumn(
                name: "name",
                table: "states");

            migrationBuilder.DropColumn(
                name: "type",
                table: "states");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "states");

            migrationBuilder.DropColumn(
                name: "wikiDataId",
                table: "states");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RequestTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RequestTypes");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "RequestTypes");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "RequestTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "RequestTypes");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "RequestTypes");

            migrationBuilder.DropColumn(
                name: "RequestName",
                table: "RequestTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "ProgramName",
                table: "Programs");

            migrationBuilder.DropColumn(
                name: "capital",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "currency",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "currency_name",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "currency_symbol",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "emoji",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "emojiU",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "flag",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "iso2",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "iso3",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "nationality",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "native",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "numeric_code",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "phonecode",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "region",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "region_id",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "subregion",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "subregion_id",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "timezones",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "tld",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "translations",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "wikiDataId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "country_code",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "country_name",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "flag",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "state_code",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "state_name",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "wikiDataId",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "states",
                newName: "State");

            migrationBuilder.RenameTable(
                name: "RequestTypes",
                newName: "RequestType");

            migrationBuilder.RenameTable(
                name: "Programs",
                newName: "Program");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "country_id",
                table: "State",
                newName: "TempId1");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "State",
                newName: "TempId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "RequestType",
                newName: "TempId");

            migrationBuilder.RenameColumn(
                name: "ProgramType",
                table: "Program",
                newName: "TempId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Country",
                newName: "TempId");

            migrationBuilder.RenameColumn(
                name: "state_id",
                table: "City",
                newName: "TempId1");

            migrationBuilder.RenameColumn(
                name: "country_id",
                table: "City",
                newName: "TempId");

            migrationBuilder.AlterColumn<int>(
                name: "TempId",
                table: "State",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "TempId",
                table: "Country",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_State_TempId",
                table: "State",
                column: "TempId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_State_TempId1",
                table: "State",
                column: "TempId1");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RequestType_TempId",
                table: "RequestType",
                column: "TempId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Program_TempId",
                table: "Program",
                column: "TempId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Country_TempId",
                table: "Country",
                column: "TempId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_City_TempId",
                table: "City",
                column: "TempId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_City_TempId1",
                table: "City",
                column: "TempId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicData_Program_ProgramId",
                table: "AcademicData",
                column: "ProgramId",
                principalTable: "Program",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalData_City_CityResidenceId",
                table: "PersonalData",
                column: "CityResidenceId",
                principalTable: "City",
                principalColumn: "TempId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalData_State_BornStateId",
                table: "PersonalData",
                column: "BornStateId",
                principalTable: "State",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDatas_Cities_BornCityId",
                table: "PersonalData",
                column: "BornCityId",
                principalTable: "City",
                principalColumn: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDatas_States_ResidenceStateId",
                table: "PersonalData",
                column: "ResidenceStateId",
                principalTable: "State",
                principalColumn: "TempId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_RequestTypes_RequestTypeId",
                table: "Tickets",
                column: "RequestTypeId",
                principalTable: "RequestType",
                principalColumn: "TempId");
        }
    }
}
