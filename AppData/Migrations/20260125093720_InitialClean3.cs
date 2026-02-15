using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.AppData.Migrations
{
    /// <inheritdoc />
    public partial class InitialClean3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin-id",
                column: "ConcurrencyStamp",
                value: "11111111-1111-1111-1111-111111111111");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Member-id",
                column: "ConcurrencyStamp",
                value: "22222222-2222-2222-2222-222222222222");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Moderator-id",
                column: "ConcurrencyStamp",
                value: "33333333-3333-3333-3333-333333333333");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
