using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRIS.Conecta.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Tickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequestTypeId = table.Column<int>(type: "int", nullable: false),
                    AgreementName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsAgreement = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Results = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateOnly>(type: "date", precision: 0, nullable: true),
                    MovilityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ContactData = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ExternalInstitution = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", precision: 0, nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", precision: 0, nullable: false),
                    TicketRequirements = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_RequestTypes_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Id",
                table: "Tickets",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Status",
                table: "Tickets",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Title",
                table: "Tickets",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RequestTypeId",
                table: "Tickets",
                column: "RequestTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
