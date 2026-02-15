using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.AppData.Migrations
{
    /// <inheritdoc />
    public partial class messagetableAdded1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "recicepntleted",
                table: "messages",
                newName: "Recipientdeleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRead",
                table: "messages",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Recipientdeleted",
                table: "messages",
                newName: "recicepntleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRead",
                table: "messages",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
