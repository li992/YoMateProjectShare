using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YoMateProjectShare.Migrations
{
    public partial class InitialProjectModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
