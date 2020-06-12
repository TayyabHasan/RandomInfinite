using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RI.API.Migrations
{
    public partial class VideoPlusUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    email = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    passwordHash = table.Column<byte[]>(nullable: true),
                    passwordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    youtubeId = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    likeCount = table.Column<double>(nullable: false),
                    dislikeCount = table.Column<double>(nullable: false),
                    views = table.Column<int>(nullable: false),
                    category = table.Column<string>(nullable: true),
                    submittedOn = table.Column<DateTime>(nullable: false),
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
                name: "Users");

            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
