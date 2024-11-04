using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRIS.Conecta.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PersonalData : Migration
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
                    IsAgreement = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    Results = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryDate = table.Column<DateOnly>(type: "date", precision: 0, nullable: true),
                    MovilityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ContactData = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ExternalInstitution = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PersonalDataId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", precision: 0, nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", precision: 0, nullable: false),
                    TicketRequirements = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                });

            migrationBuilder.CreateTable(
                name: "PersonalData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", precision: 0, nullable: false),
                    BornCountryId = table.Column<int>(type: "int", nullable: false),
                    BornStateId = table.Column<int>(type: "int", nullable: false),
                    BornCityId = table.Column<int>(type: "int", nullable: false),
                    ResidenceStateId = table.Column<int>(type: "int", nullable: false),
                    ResidenceCityId = table.Column<int>(type: "int", nullable: false),
                    AddressResidence = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PersonalEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Cellphone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    CityResidenceId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalData_Cities_CityResidenceId",
                        column: x => x.CityResidenceId,
                        principalTable: "Cities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_PersonalData_states_BornStateId",
                        column: x => x.BornStateId,
                        principalTable: "states",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalDatas_Cities_BornCityId",
                        column: x => x.BornCityId,
                        principalTable: "Cities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_PersonalDatas_Countries_BornCountryId",
                        column: x => x.BornCountryId,
                        principalTable: "Countries",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_PersonalDatas_States_ResidenceStateId",
                        column: x => x.ResidenceStateId,
                        principalTable: "states",
                        principalColumn: "id");
                   
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_PersonalData_BornCityId",
                table: "PersonalData",
                column: "BornCityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalData_BornCountryId",
                table: "PersonalData",
                column: "BornCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalData_BornStateId",
                table: "PersonalData",
                column: "BornStateId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalData_CityResidenceId",
                table: "PersonalData",
                column: "CityResidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalData_DocumentNumber",
                table: "PersonalData",
                column: "DocumentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalData_DocumentType",
                table: "PersonalData",
                column: "DocumentType");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalData_Fullname",
                table: "PersonalData",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalData_Id",
                table: "PersonalData",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalData_ResidenceStateId",
                table: "PersonalData",
                column: "ResidenceStateId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalData_TicketId",
                table: "PersonalData",
                column: "TicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalData_UserId",
                table: "PersonalData",
                column: "UserId");
           

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
                name: "PersonalData");

            migrationBuilder.DropTable(
                name: "Tickets");
       
        }
    }
}
