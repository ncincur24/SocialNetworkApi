using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class UserIdtocommentreactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CommentReaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CommentReaction_UserId",
                table: "CommentReaction",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReaction_Users_UserId",
                table: "CommentReaction",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentReaction_Users_UserId",
                table: "CommentReaction");

            migrationBuilder.DropIndex(
                name: "IX_CommentReaction_UserId",
                table: "CommentReaction");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CommentReaction");
        }
    }
}
