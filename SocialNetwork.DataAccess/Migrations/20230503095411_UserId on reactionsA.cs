using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class UserIdonreactionsA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PostReaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PostReaction_UserId",
                table: "PostReaction",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReaction_Users_UserId",
                table: "PostReaction",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostReaction_Users_UserId",
                table: "PostReaction");

            migrationBuilder.DropIndex(
                name: "IX_PostReaction_UserId",
                table: "PostReaction");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PostReaction");
        }
    }
}
