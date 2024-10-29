using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IRIS.Conecta.Identity.Migrations
{
    /// <inheritdoc />
    public partial class InitialIdentityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Identity.Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity.Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identity.Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity.Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identity.RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity.RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identity.RoleClaims_Identity.Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Identity.Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identity.UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity.UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identity.UserClaims_Identity.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Identity.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identity.UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity.UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_Identity.UserLogins_Identity.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Identity.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identity.UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity.UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Identity.UserRoles_Identity.Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Identity.Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Identity.UserRoles_Identity.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Identity.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identity.UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity.UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_Identity.UserTokens_Identity.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Identity.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Identity.Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Administrator", "ADMINISTRATOR" },
                    { "2", null, "Assistant", "ASSISTANT" },
                    { "3", null, "Student", "STUDENT" },
                    { "4", null, "Head of Department", "HEAD_OF_DEPARTMENT" }
                });

            migrationBuilder.InsertData(
                table: "Identity.Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1000", 0, "10f72db8-fa7d-4c72-bbcd-44678cd567de", "adminIrisConecta@correo.itm.edu.co", true, "System", "Admin", false, null, "adminIrisConecta@correo.itm.edu.co", "ADMIN", "AQAAAAIAAYagAAAAECa8Jtv+WwsGi9PaObOWuNQoWukdLU/VCHTQ2TsW0xWj99MV4W9KRwemGeeHzeS5PA==", null, false, "6094f356-56b5-4d5f-8b03-64dcdc441ad5", false, "admin" },
                    { "1001", 0, "5945a03d-4af8-43c1-98bc-35a753996412", "userStudent@correo.itm.edu.co", true, "USER", "Student", false, null, "USERSTUDENT@correo.itm.edu.co", "USERSTUDENT", "AQAAAAIAAYagAAAAEAruYI8qZGISk7RKJv4MlGkKv6qFf69Ws+mcMm4w2oTSKO/SoX9ueXumRXCdO8cA7g==", null, false, "ce471558-bd2f-4424-bfe5-fdfb018d76d6", false, "userStudent" },
                    { "1002", 0, "c25b01ad-30c7-4b45-9a72-bcbc7637d9ea", "assistantIrisConecta@correo.itm.edu.co", true, "System", "Assistant", false, null, "assistantIrisConecta@correo.itm.edu.co", "ASSISTANT", "AQAAAAIAAYagAAAAEO5Kg6hUnkc2fDXrL55+vY0kp1PZ7AurPKzxoHOwL5pBc4k+MCvF9gWgONWQIRTwWw==", null, false, "054d9b6b-4152-4d6d-8ec5-e3a7f548106b", false, "userAssistant" },
                    { "1003", 0, "24888407-f10f-4bc7-a0ee-028b372411b7", "headofdepartment@correo.itm.edu.co", true, "HEAD OF", "DEPARTMENT", false, null, "headofdepartment@correo.itm.edu.co", "HEADOFDEPARTMENT", "AQAAAAIAAYagAAAAEMOLxio0aLqqoXMtVbJ1aNenVUm6ILQRCLQeta2yjbIEtQoId2sHL3ltMAogntF9YQ==", null, false, "aec5079c-c338-4a21-bba8-f7d0fad1e7ca", false, "headofdepartment" }
                });

            migrationBuilder.InsertData(
                table: "Identity.UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1000" },
                    { "3", "1001" },
                    { "2", "1002" },
                    { "4", "1003" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Identity.RoleClaims_RoleId",
                table: "Identity.RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Identity.Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Identity.UserClaims_UserId",
                table: "Identity.UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Identity.UserLogins_UserId",
                table: "Identity.UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Identity.UserRoles_RoleId",
                table: "Identity.UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Identity.Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Identity.Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Identity.RoleClaims");

            migrationBuilder.DropTable(
                name: "Identity.UserClaims");

            migrationBuilder.DropTable(
                name: "Identity.UserLogins");

            migrationBuilder.DropTable(
                name: "Identity.UserRoles");

            migrationBuilder.DropTable(
                name: "Identity.UserTokens");

            migrationBuilder.DropTable(
                name: "Identity.Roles");

            migrationBuilder.DropTable(
                name: "Identity.Users");
        }
    }
}
