using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.AppData.Migrations
{
    /// <inheritdoc />
    public partial class identityMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin-id",
                column: "ConcurrencyStamp",
                value: "a4ab494b-f158-46a8-b861-d30739e2a6e8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Member-id",
                column: "ConcurrencyStamp",
                value: "ce925ef4-9d49-432e-9298-db04863d5d7e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Moderator-id",
                column: "ConcurrencyStamp",
                value: "2e10614a-6f2d-4483-a957-067c1b302d1f");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Admin-id",
                column: "ConcurrencyStamp",
                value: "b627d322-2959-4e9d-98d0-ad9d48fc5a6e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Member-id",
                column: "ConcurrencyStamp",
                value: "9e375768-8e25-4122-bee9-e774fdfcac3a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Moderator-id",
                column: "ConcurrencyStamp",
                value: "8f958fdb-99fc-4344-b101-7f2b2d6ebfe0");
        }
    }
}
