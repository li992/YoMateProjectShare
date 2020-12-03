using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YoMateProjectShare.Migrations.YoMateProjectShare
{
    public partial class RoomAccessable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatHistorys_ChatLists_ChatroomId",
                table: "ChatHistorys");

            migrationBuilder.RenameColumn(
                name: "ChatroomId",
                table: "ChatHistorys",
                newName: "chatroomId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatHistorys_ChatroomId",
                table: "ChatHistorys",
                newName: "IX_ChatHistorys_chatroomId");

            migrationBuilder.AlterColumn<int>(
                name: "chatroomId",
                table: "ChatHistorys",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ChatAccessables",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chatroomId = table.Column<int>(nullable: false),
                    uid = table.Column<string>(nullable: true),
                    joinedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatAccessables", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ChatHistorys_ChatLists_chatroomId",
                table: "ChatHistorys",
                column: "chatroomId",
                principalTable: "ChatLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatHistorys_ChatLists_chatroomId",
                table: "ChatHistorys");

            migrationBuilder.DropTable(
                name: "ChatAccessables");

            migrationBuilder.RenameColumn(
                name: "chatroomId",
                table: "ChatHistorys",
                newName: "ChatroomId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatHistorys_chatroomId",
                table: "ChatHistorys",
                newName: "IX_ChatHistorys_ChatroomId");

            migrationBuilder.AlterColumn<int>(
                name: "ChatroomId",
                table: "ChatHistorys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ChatHistorys_ChatLists_ChatroomId",
                table: "ChatHistorys",
                column: "ChatroomId",
                principalTable: "ChatLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
