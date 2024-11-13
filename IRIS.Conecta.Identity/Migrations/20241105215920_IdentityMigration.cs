using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRIS.Conecta.Identity.Migrations
{
    /// <inheritdoc />
    public partial class IdentityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Identity.Users",
                keyColumn: "Id",
                keyValue: "1000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10f72db8-fa7d-4c72-bbcd-44678cd567de", "AQAAAAIAAYagAAAAECa8Jtv+WwsGi9PaObOWuNQoWukdLU/VCHTQ2TsW0xWj99MV4W9KRwemGeeHzeS5PA==", "6094f356-56b5-4d5f-8b03-64dcdc441ad5" });

            migrationBuilder.UpdateData(
                table: "Identity.Users",
                keyColumn: "Id",
                keyValue: "1001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5945a03d-4af8-43c1-98bc-35a753996412", "AQAAAAIAAYagAAAAEAruYI8qZGISk7RKJv4MlGkKv6qFf69Ws+mcMm4w2oTSKO/SoX9ueXumRXCdO8cA7g==", "ce471558-bd2f-4424-bfe5-fdfb018d76d6" });

            migrationBuilder.UpdateData(
                table: "Identity.Users",
                keyColumn: "Id",
                keyValue: "1002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c25b01ad-30c7-4b45-9a72-bcbc7637d9ea", "AQAAAAIAAYagAAAAEO5Kg6hUnkc2fDXrL55+vY0kp1PZ7AurPKzxoHOwL5pBc4k+MCvF9gWgONWQIRTwWw==", "054d9b6b-4152-4d6d-8ec5-e3a7f548106b" });

            migrationBuilder.UpdateData(
                table: "Identity.Users",
                keyColumn: "Id",
                keyValue: "1003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24888407-f10f-4bc7-a0ee-028b372411b7", "AQAAAAIAAYagAAAAEMOLxio0aLqqoXMtVbJ1aNenVUm6ILQRCLQeta2yjbIEtQoId2sHL3ltMAogntF9YQ==", "aec5079c-c338-4a21-bba8-f7d0fad1e7ca" });
        }
    }
}
