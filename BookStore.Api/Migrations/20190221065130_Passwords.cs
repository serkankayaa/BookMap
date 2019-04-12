using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Api.Migrations
{
    public partial class Passwords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PASSWORD_HASH",
                table: "User",
                newName: "CREATED_BY");

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_DATE",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MODIFIED_BY",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MODIFIED_DATE",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USER_PASS_ID_FK",
                table: "User",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "User_Password",
                columns: table => new
                {
                    USER_PASS_ID = table.Column<Guid>(nullable: false),
                    PASSWORD_HASH = table.Column<string>(nullable: false),
                    IS_ACTIVE = table.Column<bool>(nullable: false),
                    USER_ID_FK = table.Column<Guid>(nullable: false),
                    CREATED_BY = table.Column<string>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    MODIFIED_BY = table.Column<string>(nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Password", x => x.USER_PASS_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Password");

            migrationBuilder.DropColumn(
                name: "CREATED_DATE",
                table: "User");

            migrationBuilder.DropColumn(
                name: "MODIFIED_BY",
                table: "User");

            migrationBuilder.DropColumn(
                name: "MODIFIED_DATE",
                table: "User");

            migrationBuilder.DropColumn(
                name: "USER_PASS_ID_FK",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "CREATED_BY",
                table: "User",
                newName: "PASSWORD_HASH");
        }
    }
}
