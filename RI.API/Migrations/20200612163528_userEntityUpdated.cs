using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RI.API.Migrations
{
    public partial class userEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "accountCreatedOn",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateOfBirth",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "accountCreatedOn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "dateOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "Users");
        }
    }
}
