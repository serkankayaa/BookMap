using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Api.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AUTHOR_ID",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AUTHOR_ID = table.Column<Guid>(nullable: false),
                    AUTHOR_NAME = table.Column<string>(maxLength: 250, nullable: false),
                    BIRTH_DATE = table.Column<DateTime>(nullable: false),
                    BIOGRAPHY = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AUTHOR_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AUTHOR_ID",
                table: "Books",
                column: "AUTHOR_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AUTHOR_ID",
                table: "Books",
                column: "AUTHOR_ID",
                principalTable: "Authors",
                principalColumn: "AUTHOR_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AUTHOR_ID",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Books_AUTHOR_ID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AUTHOR_ID",
                table: "Books");
        }
    }
}
