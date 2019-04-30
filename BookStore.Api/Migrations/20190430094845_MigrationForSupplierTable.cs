using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Api.Migrations
{
    public partial class MigrationForSupplierTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SUPPLIER_ID_FK",
                table: "Publisher",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SUPPLIER_ID = table.Column<Guid>(nullable: false),
                    SUPPLIER_NAME = table.Column<string>(maxLength: 250, nullable: false),
                    SUPPLIER_REGION = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SUPPLIER_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publisher_SUPPLIER_ID_FK",
                table: "Publisher",
                column: "SUPPLIER_ID_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_Publisher_Supplier_SUPPLIER_ID_FK",
                table: "Publisher",
                column: "SUPPLIER_ID_FK",
                principalTable: "Supplier",
                principalColumn: "SUPPLIER_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publisher_Supplier_SUPPLIER_ID_FK",
                table: "Publisher");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Publisher_SUPPLIER_ID_FK",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "SUPPLIER_ID_FK",
                table: "Publisher");
        }
    }
}
