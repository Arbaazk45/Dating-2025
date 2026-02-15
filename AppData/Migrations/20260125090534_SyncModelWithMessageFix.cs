using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.AppData.Migrations
{
    /// <inheritdoc />
    public partial class SyncModelWithMessageFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin-id",
                column: "ConcurrencyStamp",
                value: "ecc98c5c-9224-417b-9f28-5b7a7b63d4a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Member-id",
                column: "ConcurrencyStamp",
                value: "94d36c8e-960a-4bbf-a462-0e36ad9fe970");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Moderator-id",
                column: "ConcurrencyStamp",
                value: "04fdd99d-1942-4552-b241-041fc7d3a2e1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin-id",
                column: "ConcurrencyStamp",
                value: "5e64dcad-052d-4e9d-aca7-931aebe18b0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Member-id",
                column: "ConcurrencyStamp",
                value: "8f38d6a0-ee3f-4291-9a7d-d20ee95fc291");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Moderator-id",
                column: "ConcurrencyStamp",
                value: "1898c416-18db-4c82-a8f4-4a3962b4feb1");
        }
    }
}
