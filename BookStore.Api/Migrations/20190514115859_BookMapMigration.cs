using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Api.Migrations
{
    public partial class BookMapMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    ACCOUNT_ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(maxLength: 500, nullable: false),
                    TYPE = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ACCOUNT_ID);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AUTHOR_ID = table.Column<Guid>(nullable: false),
                    AUTHOR_NAME = table.Column<string>(maxLength: 250, nullable: false),
                    BIRTH_DATE = table.Column<DateTime>(nullable: false),
                    BIOGRAPHY = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AUTHOR_ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CATEGORY_ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(maxLength: 250, nullable: false),
                    SUMMARY = table.Column<string>(maxLength: 500, nullable: false),
                    IS_MAIN_CATEGORY = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CATEGORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    SHOP_ID = table.Column<Guid>(nullable: false),
                    SHOP_NAME = table.Column<string>(maxLength: 250, nullable: false),
                    LOCATION = table.Column<string>(nullable: true),
                    STAFF_COUNT = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.SHOP_ID);
                });

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

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    USER_ID = table.Column<Guid>(nullable: false),
                    FIRST_NAME = table.Column<string>(maxLength: 250, nullable: false),
                    SECOND_NAME = table.Column<string>(maxLength: 250, nullable: false),
                    EMAIL_ADDRESS = table.Column<string>(maxLength: 300, nullable: false),
                    EMAIL_CONFIRMED = table.Column<bool>(nullable: false),
                    BIRTH_DATE = table.Column<DateTime>(nullable: true),
                    LOCATION = table.Column<string>(nullable: true),
                    ACCOUNT_ID_FK = table.Column<Guid>(nullable: false),
                    CREATED_BY = table.Column<string>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    MODIFIED_BY = table.Column<string>(nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    PUBLISHER_ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(maxLength: 250, nullable: false),
                    LOCATION = table.Column<string>(nullable: true),
                    SUPPLIER_ID_FK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.PUBLISHER_ID);
                    table.ForeignKey(
                        name: "FK_Publisher_Supplier_SUPPLIER_ID_FK",
                        column: x => x.SUPPLIER_ID_FK,
                        principalTable: "Supplier",
                        principalColumn: "SUPPLIER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    table.ForeignKey(
                        name: "FK_User_Password_User_USER_ID_FK",
                        column: x => x.USER_ID_FK,
                        principalTable: "User",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BOOK_ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(maxLength: 250, nullable: false),
                    SUMMARY = table.Column<string>(nullable: false),
                    AUTHOR_ID_FK = table.Column<Guid>(nullable: false),
                    PUBLISHER_ID_FK = table.Column<Guid>(nullable: false),
                    ACCOUNT_ID_FK = table.Column<Guid>(nullable: false),
                    CATEGORY_ID_FK = table.Column<Guid>(nullable: false),
                    SHOP_ID_FK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BOOK_ID);
                    table.ForeignKey(
                        name: "FK_Book_Account_ACCOUNT_ID_FK",
                        column: x => x.ACCOUNT_ID_FK,
                        principalTable: "Account",
                        principalColumn: "ACCOUNT_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Author_AUTHOR_ID_FK",
                        column: x => x.AUTHOR_ID_FK,
                        principalTable: "Author",
                        principalColumn: "AUTHOR_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Category_CATEGORY_ID_FK",
                        column: x => x.CATEGORY_ID_FK,
                        principalTable: "Category",
                        principalColumn: "CATEGORY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PUBLISHER_ID_FK",
                        column: x => x.PUBLISHER_ID_FK,
                        principalTable: "Publisher",
                        principalColumn: "PUBLISHER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Shop_SHOP_ID_FK",
                        column: x => x.SHOP_ID_FK,
                        principalTable: "Shop",
                        principalColumn: "SHOP_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_ACCOUNT_ID_FK",
                table: "Book",
                column: "ACCOUNT_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Book_AUTHOR_ID_FK",
                table: "Book",
                column: "AUTHOR_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Book_CATEGORY_ID_FK",
                table: "Book",
                column: "CATEGORY_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PUBLISHER_ID_FK",
                table: "Book",
                column: "PUBLISHER_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Book_SHOP_ID_FK",
                table: "Book",
                column: "SHOP_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Publisher_SUPPLIER_ID_FK",
                table: "Publisher",
                column: "SUPPLIER_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_User_Password_USER_ID_FK",
                table: "User_Password",
                column: "USER_ID_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "User_Password");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
