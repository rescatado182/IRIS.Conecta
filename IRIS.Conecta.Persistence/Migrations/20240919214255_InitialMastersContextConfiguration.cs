using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRIS.Conecta.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMastersContextConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "RequestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestTypes_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
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
                name: "IX_TemplateResponses_Id",
                table: "TemplateResponses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TemplateResponses_RequestTypeId",
                table: "TemplateResponses",
                column: "RequestTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateResponses");

            migrationBuilder.DropTable(
                name: "RequestTypes");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
