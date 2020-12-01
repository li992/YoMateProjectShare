using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YoMateProjectShare.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(nullable: false),
                    ProjectListId = table.Column<int>(nullable: true),
                    ArticleName = table.Column<string>(maxLength: 200, nullable: true),
                    AuthorName = table.Column<string>(maxLength: 60, nullable: true),
                    UploadTime = table.Column<DateTime>(nullable: true),
                    AbstractText = table.Column<string>(nullable: true),
                    FieldOfStudy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectList_ProjectList_ProjectListId",
                        column: x => x.ProjectListId,
                        principalTable: "ProjectList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectList_ProjectListId",
                table: "ProjectList",
                column: "ProjectListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectList");
        }
    }
}
