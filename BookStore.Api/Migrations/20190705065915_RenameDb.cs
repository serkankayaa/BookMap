using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Api.Migrations
{
    public partial class RenameDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUTHOR",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(maxLength: 250, nullable: false),
                    BIRTH_DATE = table.Column<DateTime>(nullable: false),
                    BIOGRAPHY = table.Column<string>(nullable: true),
                    CREATED_BY = table.Column<string>(maxLength: 100, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_BY = table.Column<string>(maxLength: 100, nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTHOR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORY",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(maxLength: 250, nullable: false),
                    SUMMARY = table.Column<string>(maxLength: 500, nullable: false),
                    IS_MAIN_CATEGORY = table.Column<bool>(nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 100, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_BY = table.Column<string>(maxLength: 100, nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DOCUMENT",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CONTENT_TYPE = table.Column<string>(nullable: false),
                    FULL_PATH = table.Column<string>(nullable: false),
                    FILE_NAME = table.Column<string>(nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 100, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_BY = table.Column<string>(maxLength: 100, nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOCUMENT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SHOP",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(maxLength: 250, nullable: false),
                    LOCATION = table.Column<string>(maxLength: 200, nullable: true),
                    STAFF_COUNT = table.Column<int>(nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 100, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_BY = table.Column<string>(maxLength: 100, nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHOP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIER",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(maxLength: 250, nullable: false),
                    REGION = table.Column<string>(maxLength: 200, nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 100, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_BY = table.Column<string>(maxLength: 100, nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    EMAIL_ADDRESS = table.Column<string>(maxLength: 250, nullable: false),
                    EMAIL_CONFIRMED = table.Column<bool>(nullable: false),
                    VERIFICATION_CODE = table.Column<string>(nullable: true),
                    USER_NAME = table.Column<string>(maxLength: 150, nullable: false),
                    ROLE = table.Column<byte>(nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 100, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_BY = table.Column<string>(maxLength: 100, nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PUBLISHER",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(maxLength: 250, nullable: false),
                    LOCATION = table.Column<string>(maxLength: 200, nullable: true),
                    SUPPLIER_ID_FK = table.Column<Guid>(nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 100, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_BY = table.Column<string>(maxLength: 100, nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PUBLISHER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PUBLISHER_SUPPLIER_SUPPLIER_ID_FK",
                        column: x => x.SUPPLIER_ID_FK,
                        principalTable: "SUPPLIER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_LOG",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    USER_ID_FK = table.Column<Guid>(nullable: false),
                    LOGIN_DATE = table.Column<DateTime>(nullable: false),
                    LOGOUT_DATE = table.Column<DateTime>(nullable: false),
                    TOKEN = table.Column<string>(nullable: true),
                    CREATED_BY = table.Column<string>(maxLength: 100, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_BY = table.Column<string>(nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_LOG", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_LOG_USER_USER_ID_FK",
                        column: x => x.USER_ID_FK,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_PASSWORD",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    USER_ID_FK = table.Column<Guid>(nullable: false),
                    PASSWORD_HASH = table.Column<string>(nullable: false),
                    IS_ACTIVE = table.Column<bool>(nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 100, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_BY = table.Column<string>(maxLength: 100, nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_PASSWORD", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_PASSWORD_USER_USER_ID_FK",
                        column: x => x.USER_ID_FK,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_PROFILE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    USER_ID_FK = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(maxLength: 100, nullable: false),
                    SURNAME = table.Column<string>(maxLength: 100, nullable: false),
                    ADDRESS = table.Column<string>(nullable: true),
                    BIRTHDATE = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 100, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_BY = table.Column<string>(maxLength: 100, nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_PROFILE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_PROFILE_USER_USER_ID_FK",
                        column: x => x.USER_ID_FK,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BOOK",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(maxLength: 250, nullable: false),
                    SUMMARY = table.Column<string>(nullable: false),
                    AUTHOR_ID_FK = table.Column<Guid>(nullable: false),
                    PUBLISHER_ID_FK = table.Column<Guid>(nullable: false),
                    CATEGORY_ID_FK = table.Column<Guid>(nullable: false),
                    SHOP_ID_FK = table.Column<Guid>(nullable: false),
                    DOCUMENT_ID_FK = table.Column<Guid>(nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 100, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_BY = table.Column<string>(maxLength: 100, nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BOOK_AUTHOR_AUTHOR_ID_FK",
                        column: x => x.AUTHOR_ID_FK,
                        principalTable: "AUTHOR",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOOK_CATEGORY_CATEGORY_ID_FK",
                        column: x => x.CATEGORY_ID_FK,
                        principalTable: "CATEGORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOOK_DOCUMENT_DOCUMENT_ID_FK",
                        column: x => x.DOCUMENT_ID_FK,
                        principalTable: "DOCUMENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOOK_PUBLISHER_PUBLISHER_ID_FK",
                        column: x => x.PUBLISHER_ID_FK,
                        principalTable: "PUBLISHER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOOK_SHOP_SHOP_ID_FK",
                        column: x => x.SHOP_ID_FK,
                        principalTable: "SHOP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_BOOK",
                columns: table => new
                {
                    USER_ID_FK = table.Column<Guid>(nullable: false),
                    BOOK_ID_FK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_BOOK", x => new { x.BOOK_ID_FK, x.USER_ID_FK });
                    table.ForeignKey(
                        name: "FK_USER_BOOK_BOOK_BOOK_ID_FK",
                        column: x => x.BOOK_ID_FK,
                        principalTable: "BOOK",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_BOOK_USER_USER_ID_FK",
                        column: x => x.USER_ID_FK,
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOOK_AUTHOR_ID_FK",
                table: "BOOK",
                column: "AUTHOR_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BOOK_CATEGORY_ID_FK",
                table: "BOOK",
                column: "CATEGORY_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BOOK_DOCUMENT_ID_FK",
                table: "BOOK",
                column: "DOCUMENT_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BOOK_PUBLISHER_ID_FK",
                table: "BOOK",
                column: "PUBLISHER_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_BOOK_SHOP_ID_FK",
                table: "BOOK",
                column: "SHOP_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_PUBLISHER_SUPPLIER_ID_FK",
                table: "PUBLISHER",
                column: "SUPPLIER_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_USER_BOOK_USER_ID_FK",
                table: "USER_BOOK",
                column: "USER_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_USER_LOG_USER_ID_FK",
                table: "USER_LOG",
                column: "USER_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_USER_PASSWORD_USER_ID_FK",
                table: "USER_PASSWORD",
                column: "USER_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_USER_PROFILE_USER_ID_FK",
                table: "USER_PROFILE",
                column: "USER_ID_FK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USER_BOOK");

            migrationBuilder.DropTable(
                name: "USER_LOG");

            migrationBuilder.DropTable(
                name: "USER_PASSWORD");

            migrationBuilder.DropTable(
                name: "USER_PROFILE");

            migrationBuilder.DropTable(
                name: "BOOK");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "AUTHOR");

            migrationBuilder.DropTable(
                name: "CATEGORY");

            migrationBuilder.DropTable(
                name: "DOCUMENT");

            migrationBuilder.DropTable(
                name: "PUBLISHER");

            migrationBuilder.DropTable(
                name: "SHOP");

            migrationBuilder.DropTable(
                name: "SUPPLIER");
        }
    }
}
