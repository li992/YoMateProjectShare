using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YoMateProjectShare.Migrations.YoMateProjectShareDB
{
    public partial class SpecificUserDetials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ChatsId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateJoined",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FriendsId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectsId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChatList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatListId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatList_ChatList_ChatListId",
                        column: x => x.ChatListId,
                        principalTable: "ChatList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendListId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendList_FriendList_FriendListId",
                        column: x => x.FriendListId,
                        principalTable: "FriendList",
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
                    AbstractText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leftChildId = table.Column<int>(nullable: true),
                    rightChildId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectList_Projects_leftChildId",
                        column: x => x.leftChildId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectList_ProjectList_rightChildId",
                        column: x => x.rightChildId,
                        principalTable: "ProjectList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChatsId",
                table: "AspNetUsers",
                column: "ChatsId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FriendsId",
                table: "AspNetUsers",
                column: "FriendsId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProjectsId",
                table: "AspNetUsers",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatList_ChatListId",
                table: "ChatList",
                column: "ChatListId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendList_FriendListId",
                table: "FriendList",
                column: "FriendListId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectList_leftChildId",
                table: "ProjectList",
                column: "leftChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectList_rightChildId",
                table: "ProjectList",
                column: "rightChildId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ChatList_ChatsId",
                table: "AspNetUsers",
                column: "ChatsId",
                principalTable: "ChatList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_FriendList_FriendsId",
                table: "AspNetUsers",
                column: "FriendsId",
                principalTable: "FriendList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ProjectList_ProjectsId",
                table: "AspNetUsers",
                column: "ProjectsId",
                principalTable: "ProjectList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ChatList_ChatsId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_FriendList_FriendsId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ProjectList_ProjectsId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ChatList");

            migrationBuilder.DropTable(
                name: "FriendList");

            migrationBuilder.DropTable(
                name: "ProjectList");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ChatsId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FriendsId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProjectsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ChatsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateJoined",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FriendsId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProjectsId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
