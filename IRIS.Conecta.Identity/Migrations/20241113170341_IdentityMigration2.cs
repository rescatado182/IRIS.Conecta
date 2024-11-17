using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRIS.Conecta.Identity.Migrations
{
    /// <inheritdoc />
    public partial class IdentityMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Identity.Users",
                keyColumn: "Id",
                keyValue: "1000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c092a48-5810-478d-acd5-e724d511603b", "AQAAAAIAAYagAAAAEAKkh51BdtXCnHiQR5TSYpI7bHsbeeojk3rRrF/m4/PzVwaxH3smv20T6lTgtRhcXA==", "8d82ebba-eeb6-4b1a-8026-cefa33fac69c" });

            migrationBuilder.UpdateData(
                table: "Identity.Users",
                keyColumn: "Id",
                keyValue: "1001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee1e1759-4428-48db-a22c-67437fade024", "AQAAAAIAAYagAAAAEAC9kVIM7Zu9+/ai57CFXC4buOcAPWmZIiSjoAu8VjoVcV7Iyf1Ca9vkdqpUzUdwmw==", "66d717ae-8b45-4548-b49d-627c09e720db" });

            migrationBuilder.UpdateData(
                table: "Identity.Users",
                keyColumn: "Id",
                keyValue: "1002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39e3e1eb-c8e7-4884-97ec-6cedef2aefdd", "AQAAAAIAAYagAAAAECW1sIh9V68vZJqhjTN/kYolFtmFY7aHOqj5u9/x43fCyqpCP6vMDLkNs6NX9ZsCag==", "7d8ee43d-2e37-4ab9-a542-25bf60c3a5ec" });

            migrationBuilder.UpdateData(
                table: "Identity.Users",
                keyColumn: "Id",
                keyValue: "1003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91d2cf99-169a-42e3-bdb9-0d288e32f5e8", "AQAAAAIAAYagAAAAEDQ/YJqW8wO6ndvCIoyMtjPVSVqpKHIV6+HzPCDVnB1gw4Bu2GeXEQrBqV52N1Z4Ng==", "db9fc272-604c-48dd-a256-b19f1802ebba" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Identity.Users",
                keyColumn: "Id",
                keyValue: "1000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bcc0349-0929-4e11-9851-50957d68ad29", "AQAAAAIAAYagAAAAEN21kVyfjQQy5qwFNTdZE/XXtWraZw/Hc7JUA63ZksTMtLPJClhEfpyfIA02G0nDgA==", "d45a9e4f-94b7-404c-8f5e-16552fa3a765" });

            migrationBuilder.UpdateData(
                table: "Identity.Users",
                keyColumn: "Id",
                keyValue: "1001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e09a4448-f591-4438-99c2-0e368086d5fb", "AQAAAAIAAYagAAAAEB2MDEX02zXdMMKk9BYJ43/AMC/HQcrdRDvlWvY2BA05BHJ4dZQqGh7zofozVsO5vA==", "e6a632a6-7eba-4b58-9bf1-d9bbf9d76d5d" });

            migrationBuilder.UpdateData(
                table: "Identity.Users",
                keyColumn: "Id",
                keyValue: "1002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a226fa8-0317-4aec-a05c-3cdb2c48b5f0", "AQAAAAIAAYagAAAAEE8hWd4WQoVkwd7MCwMw8TQWUZo1BK71pL+tD3CGm8rFdynMKn0znGkRLLtzK79yuw==", "abdf8ce0-df31-40b5-a668-8a7602c47e79" });

            migrationBuilder.UpdateData(
                table: "Identity.Users",
                keyColumn: "Id",
                keyValue: "1003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "885288fd-882e-4873-aa58-0e49197b5aa1", "AQAAAAIAAYagAAAAENSKT9dWKlf3vkDlPq5e63Q2VM29KVcYoPL4Q25FPrK+v6BHBL7n6vlK9Ur8mvvBBA==", "a21844ea-b4a2-4e36-856f-c402fd47ac3a" });
        }
    }
}
