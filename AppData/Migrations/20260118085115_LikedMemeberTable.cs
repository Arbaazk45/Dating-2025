using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.AppData.Migrations
{
    /// <inheritdoc />
    public partial class LikedMemeberTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "memberLikes",
                columns: table => new
                {
                    SourceMemberId = table.Column<string>(type: "TEXT", nullable: false),
                    TargetMemberId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memberLikes", x => new { x.SourceMemberId, x.TargetMemberId });
                    table.ForeignKey(
                        name: "FK_memberLikes_members_SourceMemberId",
                        column: x => x.SourceMemberId,
                        principalTable: "members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_memberLikes_members_TargetMemberId",
                        column: x => x.TargetMemberId,
                        principalTable: "members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_memberLikes_TargetMemberId",
                table: "memberLikes",
                column: "TargetMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "memberLikes");
        }
    }
}
