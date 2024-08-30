using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QMSWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalUserFiledsForRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bcae7e0-95a7-4275-b90a-c5e58cd2a838");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "417394bd-0873-45eb-ae9a-e0406eeb741d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de606949-3321-4997-a9a9-c54ae283ddb9");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14c8ef9e-3a68-4336-94cd-565be0794bab", null, "IMT", "IMT" },
                    { "a8defb49-f6b5-4f51-8978-017ec6893482", null, "Personnel", "PERSONNEL" },
                    { "ebe9e7ee-0e01-490c-bd5a-d71b756bb3cd", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 29, 20, 5, 45, 770, DateTimeKind.Utc).AddTicks(7569), new DateTime(2024, 8, 29, 20, 5, 45, 770, DateTimeKind.Utc).AddTicks(7573) });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 29, 20, 5, 45, 770, DateTimeKind.Utc).AddTicks(7576), new DateTime(2024, 8, 29, 20, 5, 45, 770, DateTimeKind.Utc).AddTicks(7576) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14c8ef9e-3a68-4336-94cd-565be0794bab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8defb49-f6b5-4f51-8978-017ec6893482");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebe9e7ee-0e01-490c-bd5a-d71b756bb3cd");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2bcae7e0-95a7-4275-b90a-c5e58cd2a838", null, "Administrator", "ADMINISTRATOR" },
                    { "417394bd-0873-45eb-ae9a-e0406eeb741d", null, "Personnel", "PERSONNEL" },
                    { "de606949-3321-4997-a9a9-c54ae283ddb9", null, "IMT", "IMT" }
                });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 8, 18, 10, 30, 348, DateTimeKind.Utc).AddTicks(6036), new DateTime(2024, 8, 8, 18, 10, 30, 348, DateTimeKind.Utc).AddTicks(6040) });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 8, 18, 10, 30, 348, DateTimeKind.Utc).AddTicks(6043), new DateTime(2024, 8, 8, 18, 10, 30, 348, DateTimeKind.Utc).AddTicks(6043) });
        }
    }
}
