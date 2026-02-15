using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.AppData.Migrations
{
    /// <inheritdoc />
    public partial class identityMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
