using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Api.Migrations
{
    public partial class deletedSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PUBLISHER_SUPPLIER_SUPPLIER_ID_FK",
                table: "PUBLISHER");

            migrationBuilder.DropTable(
                name: "SUPPLIER");

            migrationBuilder.DropIndex(
                name: "IX_PUBLISHER_SUPPLIER_ID_FK",
                table: "PUBLISHER");

            migrationBuilder.DropColumn(
                name: "SUPPLIER_ID_FK",
                table: "PUBLISHER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SUPPLIER_ID_FK",
                table: "PUBLISHER",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SUPPLIER",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 100, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    NAME = table.Column<string>(maxLength: 250, nullable: false),
                    REGION = table.Column<string>(maxLength: 200, nullable: false),
                    UPDATED_BY = table.Column<string>(maxLength: 100, nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PUBLISHER_SUPPLIER_ID_FK",
                table: "PUBLISHER",
                column: "SUPPLIER_ID_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_PUBLISHER_SUPPLIER_SUPPLIER_ID_FK",
                table: "PUBLISHER",
                column: "SUPPLIER_ID_FK",
                principalTable: "SUPPLIER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
