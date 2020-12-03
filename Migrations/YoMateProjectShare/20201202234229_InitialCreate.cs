using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YoMateProjectShare.Migrations.YoMateProjectShare
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatListId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatLists_ChatLists_ChatListId",
                        column: x => x.ChatListId,
                        principalTable: "ChatLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    belongtoId = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    FriendListId = table.Column<int>(nullable: true),
                    friendId = table.Column<string>(nullable: true),
                    friendNickname = table.Column<string>(nullable: true),
                    addingTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendLists_FriendLists_FriendListId",
                        column: x => x.FriendListId,
                        principalTable: "FriendLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleName = table.Column<string>(maxLength: 200, nullable: true),
                    AuthorName = table.Column<string>(maxLength: 60, nullable: true),
                    UploadTime = table.Column<DateTime>(nullable: false),
                    AbstractText = table.Column<string>(nullable: true),
                    FieldOfStudy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatHistorys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    message = table.Column<string>(nullable: true),
                    userId = table.Column<int>(nullable: false),
                    sendingTime = table.Column<DateTime>(nullable: false),
                    ChatroomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatHistorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatHistorys_ChatLists_ChatroomId",
                        column: x => x.ChatroomId,
                        principalTable: "ChatLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatHistorys_ChatroomId",
                table: "ChatHistorys",
                column: "ChatroomId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatLists_ChatListId",
                table: "ChatLists",
                column: "ChatListId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendLists_FriendListId",
                table: "FriendLists",
                column: "FriendListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatHistorys");

            migrationBuilder.DropTable(
                name: "FriendLists");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ChatLists");
        }
    }
}
