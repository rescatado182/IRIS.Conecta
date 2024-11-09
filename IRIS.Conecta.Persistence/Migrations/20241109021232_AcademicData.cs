using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRIS.Conecta.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AcademicData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {           

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
          
            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProgramType = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programs_Deparments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AcademicData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    ResearchProject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramType = table.Column<int>(type: "int", nullable: false),
                    AverageCredit = table.Column<double>(type: "float", nullable: false),
                    EnrolledSemester = table.Column<int>(type: "int", nullable: false),
                    ResearchGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionalGroup = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicData_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicData_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicData_Id",
                table: "AcademicData",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicData_ProgramId",
                table: "AcademicData",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicData_TicketId",
                table: "AcademicData",
                column: "TicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicData_TicketIdId",
                table: "AcademicData",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicData_UserId",
                table: "AcademicData",
                column: "UserId");           

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
           
        }
    }
}
