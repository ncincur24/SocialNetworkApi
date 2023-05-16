using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class Groupchats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupChatUsers",
                table: "GroupChatUsers");

            migrationBuilder.DropIndex(
                name: "IX_GroupChatUsers_UserId",
                table: "GroupChatUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GroupChatUsers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GroupChatUsers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "GroupChatUsers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "GroupChatUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "GroupChatUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Reactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedAt",
                table: "GroupChatUsers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GroupChats",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "GroupChats",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "GroupChats",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Files",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupChatUsers",
                table: "GroupChatUsers",
                columns: new[] { "UserId", "GroupChatId" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupChats_Name",
                table: "GroupChats",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupChatUsers",
                table: "GroupChatUsers");

            migrationBuilder.DropIndex(
                name: "IX_GroupChats_Name",
                table: "GroupChats");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "AddedAt",
                table: "GroupChatUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "GroupChats");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Files");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GroupChatUsers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GroupChatUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "GroupChatUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "GroupChatUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "GroupChatUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GroupChats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "GroupChats",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupChatUsers",
                table: "GroupChatUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChatUsers_UserId",
                table: "GroupChatUsers",
                column: "UserId");
        }
    }
}
