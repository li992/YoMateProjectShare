using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YoMateProjectShare.Migrations.YoMateProjectShareDB
{
    public partial class ProjectModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectList_Projects_leftChildId",
                table: "ProjectList");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectList_ProjectList_rightChildId",
                table: "ProjectList");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_ProjectList_leftChildId",
                table: "ProjectList");

            migrationBuilder.DropIndex(
                name: "IX_ProjectList_rightChildId",
                table: "ProjectList");

            migrationBuilder.DropColumn(
                name: "leftChildId",
                table: "ProjectList");

            migrationBuilder.DropColumn(
                name: "rightChildId",
                table: "ProjectList");

            migrationBuilder.AddColumn<int>(
                name: "ProjectListId",
                table: "ProjectList",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectList_ProjectListId",
                table: "ProjectList",
                column: "ProjectListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectList_ProjectList_ProjectListId",
                table: "ProjectList",
                column: "ProjectListId",
                principalTable: "ProjectList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectList_ProjectList_ProjectListId",
                table: "ProjectList");

            migrationBuilder.DropIndex(
                name: "IX_ProjectList_ProjectListId",
                table: "ProjectList");

            migrationBuilder.DropColumn(
                name: "ProjectListId",
                table: "ProjectList");

            migrationBuilder.AddColumn<int>(
                name: "leftChildId",
                table: "ProjectList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "rightChildId",
                table: "ProjectList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbstractText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuthorName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    UploadTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectList_leftChildId",
                table: "ProjectList",
                column: "leftChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectList_rightChildId",
                table: "ProjectList",
                column: "rightChildId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectList_Projects_leftChildId",
                table: "ProjectList",
                column: "leftChildId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectList_ProjectList_rightChildId",
                table: "ProjectList",
                column: "rightChildId",
                principalTable: "ProjectList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
