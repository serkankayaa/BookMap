using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Api.Migrations
{
    public partial class BookStoreMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MODIFIED_BY",
                table: "User_Password");

            migrationBuilder.DropColumn(
                name: "MODIFIED_DATE",
                table: "User_Password");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MODIFIED_BY",
                table: "User_Password",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MODIFIED_DATE",
                table: "User_Password",
                nullable: true);
        }
    }
}
