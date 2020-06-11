using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RI.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    youtubeId = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    likeCount = table.Column<double>(nullable: true),
                    dislikeCount = table.Column<double>(nullable: true),
                    views = table.Column<int>(nullable: true),
                    category = table.Column<string>(nullable: true),
                    submittedOn = table.Column<DateTime>(nullable: true),
                    submittedBy = table.Column<string>(nullable: true),
                    submittedUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
