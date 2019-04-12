using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Api.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    USER_ID = table.Column<Guid>(nullable: false),
                    FIRST_NAME = table.Column<string>(maxLength: 250, nullable: false),
                    SECOND_NAME = table.Column<string>(maxLength: 250, nullable: false),
                    EMAIL_ADDRESS = table.Column<string>(maxLength: 300, nullable: false),
                    PASSWORD_HASH = table.Column<string>(nullable: false),
                    BIRTH_DATE = table.Column<DateTime>(nullable: true),
                    LOCATION = table.Column<string>(nullable: true),
                    ACCOUNT_ID_FK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.USER_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
