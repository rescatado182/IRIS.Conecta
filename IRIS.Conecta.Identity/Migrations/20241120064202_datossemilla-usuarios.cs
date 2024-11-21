using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IRIS.Conecta.Identity.Migrations
{
    /// <inheritdoc />
    public partial class datossemillausuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Identity.Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1000", 0, "a2e80e61-8bdd-4db8-a30d-62608b6e3b4f", "adminIrisConecta@correo.itm.edu.co", true, "System", "Admin", false, null, "adminIrisConecta@correo.itm.edu.co", "ADMIN", "AQAAAAIAAYagAAAAECeKC/74mdlBpzs3ra4HcIu2hTZ+wuJjav3Hp3HYvi+ZLksK4jBjwcZMZRpwG+WuSQ==", null, false, "dfe9c304-0513-49ea-8401-a6bde0184a42", false, "admin" },
                    { "1001", 0, "ac1ab571-f178-4683-9b20-a9bf38f92c79", "userStudent@correo.itm.edu.co", true, "USER", "Student", false, null, "USERSTUDENT@correo.itm.edu.co", "USERSTUDENT", "AQAAAAIAAYagAAAAEIi7GwWsaLNpehczkJ0Lloka8xrXUVhvddaxEIDVbkGcMViClaBI5Fy9gwZmdBpVvw==", null, false, "ece7090e-6e52-4016-8569-acc5ceaecb75", false, "userStudent" },
                    { "1002", 0, "b0d1e114-1af4-4213-92b2-11d7d8001c8c", "assistantIrisConecta@correo.itm.edu.co", true, "System", "Assistant", false, null, "assistantIrisConecta@correo.itm.edu.co", "ASSISTANT", "AQAAAAIAAYagAAAAEPmAvcalPt7qMd3DfI7hRy8s1DxeSdJf/59QUNljnLVMzmay8L/BaX0PZiyror5w5w==", null, false, "5e2d8e40-1178-4047-b16b-ad40496a67ed", false, "userAssistant" },
                    { "1003", 0, "e45406a4-bd3c-42d1-8659-27d8e1687f8e", "headofdepartment@correo.itm.edu.co", true, "HEAD OF", "DEPARTMENT", false, null, "headofdepartment@correo.itm.edu.co", "HEADOFDEPARTMENT", "AQAAAAIAAYagAAAAEJivJ3Tz+sJbUh9c+WVWPYpyNdp1FXQVkk3vbj9gbOQaDJfsI58bkGgl9hmp3g3Ubw==", null, false, "abb77dcf-910f-4fe7-9d2c-01793931454d", false, "headofdepartment" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Identity.Users",
                keyColumn: "Id",
                keyValue: "1000");

            migrationBuilder.DeleteData(
                table: "Identity.Users",
                keyColumn: "Id",
                keyValue: "1001");

            migrationBuilder.DeleteData(
                table: "Identity.Users",
                keyColumn: "Id",
                keyValue: "1002");

            migrationBuilder.DeleteData(
                table: "Identity.Users",
                keyColumn: "Id",
                keyValue: "1003");
        }
    }
}
