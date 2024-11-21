using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IRIS.Conecta.Identity.Migrations
{
    /// <inheritdoc />
    public partial class datossemilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { "1000", 0, "401b0498-2faa-42fd-aeb0-15f79a7b5793", "adminIrisConecta@correo.itm.edu.co", true, "System", "Admin", false, null, "adminIrisConecta@correo.itm.edu.co", "ADMIN", "AQAAAAIAAYagAAAAEDWTPYx6eysttKmDvBNvVKQDp4A8WyHKltIwsCh8u9gllJJHp8fb2P+Q5/QkeiU5hQ==", null, false, "7a6dcf1c-a247-42f8-8426-6dd2078db28e", false, "admin" },
                    { "1001", 0, "ad5d9991-bf73-4be7-b07c-991d47382481", "userStudent@correo.itm.edu.co", true, "USER", "Student", false, null, "USERSTUDENT@correo.itm.edu.co", "USERSTUDENT", "AQAAAAIAAYagAAAAEB9PWX8lpJV3NFIlDSvsS+nO4qE6kp2Hdn0WZrRaGf3R28JWUACUYNgxiGtlm+b05g==", null, false, "9e138e6f-7c99-47a4-b81d-a5f8cd444660", false, "userStudent" },
                    { "1002", 0, "eccc3acb-5a04-4f80-b098-1b802d1adf15", "assistantIrisConecta@correo.itm.edu.co", true, "System", "Assistant", false, null, "assistantIrisConecta@correo.itm.edu.co", "ASSISTANT", "AQAAAAIAAYagAAAAEEyeajKrsB8oS06rozRlNWhm3MVeRHQldLPMy9UhmNjXQC+wdir5hEEj+oW3lht/aw==", null, false, "75054623-e40d-4f48-bfe2-0ccacba97674", false, "userAssistant" },
                    { "1003", 0, "a40a0ff5-97a6-41dc-b3dc-c27c7ca03530", "headofdepartment@correo.itm.edu.co", true, "HEAD OF", "DEPARTMENT", false, null, "headofdepartment@correo.itm.edu.co", "HEADOFDEPARTMENT", "AQAAAAIAAYagAAAAEOtxBdaSMTuLozIyu2KpVMX0FIlYI6KKpNMFsFvgMZ3mQq+f19QWh3pziho8sA0bKg==", null, false, "556f9eb6-f5df-4362-8a45-6bcd50a3e378", false, "headofdepartment" }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Identity.UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1000" });

            migrationBuilder.DeleteData(
                table: "Identity.UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "1001" });

            migrationBuilder.DeleteData(
                table: "Identity.UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "1002" });

            migrationBuilder.DeleteData(
                table: "Identity.UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4", "1003" });

            migrationBuilder.DeleteData(
                table: "Identity.Roles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Identity.Roles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Identity.Roles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Identity.Roles",
                keyColumn: "Id",
                keyValue: "4");

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
