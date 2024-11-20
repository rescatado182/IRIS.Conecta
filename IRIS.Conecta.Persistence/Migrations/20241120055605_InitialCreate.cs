using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRIS.Conecta.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    iso3 = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: true),
                    numeric_code = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: true),
                    iso2 = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: true),
                    phonecode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    capital = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    currency = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    currency_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    currency_symbol = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    tld = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    native = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    region = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    region_id = table.Column<int>(type: "int", nullable: true),
                    subregion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    subregion_id = table.Column<int>(type: "int", nullable: true),
                    nationality = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    timezones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    translations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    latitude = table.Column<decimal>(type: "decimal(10,8)", nullable: true),
                    longitude = table.Column<decimal>(type: "decimal(11,8)", nullable: true),
                    emoji = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    emojiU = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    flag = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    wikiDataId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Countrie__3213E83FA74F3AF0", x => x.id);
                });

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
                name: "states",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    country_id = table.Column<int>(type: "int", nullable: false),
                    country_code = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false),
                    fips_code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    iso2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    type = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    latitude = table.Column<decimal>(type: "decimal(10,8)", nullable: true),
                    longitude = table.Column<decimal>(type: "decimal(11,8)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    flag = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    wikiDataId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__states__3213E83F220489F8", x => x.id);
                    table.ForeignKey(
                        name: "FK_states_countries",
                        column: x => x.country_id,
                        principalTable: "Countries",
                        principalColumn: "id");
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
                name: "Cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    state_id = table.Column<int>(type: "int", nullable: false),
                    state_code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    state_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    country_id = table.Column<int>(type: "int", nullable: false),
                    country_code = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false),
                    country_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    latitude = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    longitude = table.Column<decimal>(type: "decimal(11,8)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2014, 1, 1, 12, 1, 1, 0, DateTimeKind.Unspecified)),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    flag = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    wikiDataId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cities__3213E83FCFF12A69", x => x.id);
                    table.ForeignKey(
                        name: "FK_cities_countries",
                        column: x => x.country_id,
                        principalTable: "Countries",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_cities_states",
                        column: x => x.state_id,
                        principalTable: "states",
                        principalColumn: "id");
                });

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
                name: "RequestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalDataId = table.Column<int>(type: "int", nullable: false),
                    AcademicDataId = table.Column<int>(type: "int", nullable: false),
                    StartDateMovility = table.Column<DateOnly>(type: "date", precision: 0, nullable: false),
                    EndDateMovility = table.Column<DateOnly>(type: "date", precision: 0, nullable: false),
                    StartDateRequirement = table.Column<DateOnly>(type: "date", precision: 0, nullable: false),
                    EndDateRequirement = table.Column<DateOnly>(type: "date", precision: 0, nullable: false),
                    TicketRequirements = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, defaultValue: "False"),
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

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SendEmail = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    ManagerUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_RequestTypes_Id",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "False"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalData_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
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
                name: "IX_Notifications_Id",
                table: "Notifications",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ManagerUserId",
                table: "Notifications",
                column: "ManagerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_NotificationType",
                table: "Notifications",
                column: "NotificationType");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TicketId",
                table: "Notifications",
                column: "TicketId");

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
                name: "IX_states_country_id",
                table: "states",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateResponses_Id",
                table: "TemplateResponses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TemplateResponses_RequestTypeId",
                table: "TemplateResponses",
                column: "RequestTypeId");

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
                name: "AcademicData");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PersonalData");

            migrationBuilder.DropTable(
                name: "TemplateResponses");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "RequestTypes");

            migrationBuilder.DropTable(
                name: "states");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
