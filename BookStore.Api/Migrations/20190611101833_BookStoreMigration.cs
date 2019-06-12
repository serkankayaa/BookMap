using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Api.Migrations
{
    public partial class BookStoreMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Account_ACCOUNT_ID_FK",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropColumn(
                name: "ACCOUNT_ID_FK",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BIRTH_DATE",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FIRST_NAME",
                table: "User");

            migrationBuilder.DropColumn(
                name: "MODIFIED_DATE",
                table: "User");

            migrationBuilder.DropColumn(
                name: "SECOND_NAME",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "USER_PASS_ID",
                table: "User_Password",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "MODIFIED_BY",
                table: "User",
                newName: "VERIFICATION_CODE");

            migrationBuilder.RenameColumn(
                name: "LOCATION",
                table: "User",
                newName: "UPDATED_BY");

            migrationBuilder.RenameColumn(
                name: "USER_ID",
                table: "User",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ACCOUNT_ID_FK",
                table: "Book",
                newName: "DOCUMENT_ID_FK");

            migrationBuilder.RenameIndex(
                name: "IX_Book_ACCOUNT_ID_FK",
                table: "Book",
                newName: "IX_Book_DOCUMENT_ID_FK");

            migrationBuilder.AddColumn<string>(
                name: "UPDATED_BY",
                table: "User_Password",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_DATE",
                table: "User_Password",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL_ADDRESS",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 300);

            migrationBuilder.AddColumn<byte>(
                name: "ROLE",
                table: "User",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_DATE",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "USER_NAME",
                table: "User",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "User_Book",
                columns: table => new
                {
                    USER_ID_FK = table.Column<Guid>(nullable: false),
                    BOOK_ID_FK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Book", x => new { x.BOOK_ID_FK, x.USER_ID_FK });
                    table.ForeignKey(
                        name: "FK_User_Book_Book_BOOK_ID_FK",
                        column: x => x.BOOK_ID_FK,
                        principalTable: "Book",
                        principalColumn: "BOOK_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Book_User_USER_ID_FK",
                        column: x => x.USER_ID_FK,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Log",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    USER_ID_FK = table.Column<Guid>(nullable: false),
                    LOGIN_DATE = table.Column<DateTime>(nullable: false),
                    LOGOUT_DATE = table.Column<DateTime>(nullable: false),
                    TOKEN = table.Column<string>(nullable: true),
                    CREATED_BY = table.Column<string>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_BY = table.Column<string>(nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Log", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_Log_User_USER_ID_FK",
                        column: x => x.USER_ID_FK,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Profile",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    USER_ID_FK = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(nullable: false),
                    SURNAME = table.Column<string>(nullable: false),
                    ADDRESS = table.Column<string>(nullable: false),
                    BIRTHDATE = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<string>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_BY = table.Column<string>(nullable: true),
                    UPDATED_DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Profile", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_Profile_User_USER_ID_FK",
                        column: x => x.USER_ID_FK,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Book_USER_ID_FK",
                table: "User_Book",
                column: "USER_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_User_Log_USER_ID_FK",
                table: "User_Log",
                column: "USER_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_User_Profile_USER_ID_FK",
                table: "User_Profile",
                column: "USER_ID_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Document_DOCUMENT_ID_FK",
                table: "Book",
                column: "DOCUMENT_ID_FK",
                principalTable: "Document",
                principalColumn: "DOCUMENT_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Document_DOCUMENT_ID_FK",
                table: "Book");

            migrationBuilder.DropTable(
                name: "User_Book");

            migrationBuilder.DropTable(
                name: "User_Log");

            migrationBuilder.DropTable(
                name: "User_Profile");

            migrationBuilder.DropColumn(
                name: "UPDATED_BY",
                table: "User_Password");

            migrationBuilder.DropColumn(
                name: "UPDATED_DATE",
                table: "User_Password");

            migrationBuilder.DropColumn(
                name: "ROLE",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UPDATED_DATE",
                table: "User");

            migrationBuilder.DropColumn(
                name: "USER_NAME",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "User_Password",
                newName: "USER_PASS_ID");

            migrationBuilder.RenameColumn(
                name: "VERIFICATION_CODE",
                table: "User",
                newName: "MODIFIED_BY");

            migrationBuilder.RenameColumn(
                name: "UPDATED_BY",
                table: "User",
                newName: "LOCATION");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "User",
                newName: "USER_ID");

            migrationBuilder.RenameColumn(
                name: "DOCUMENT_ID_FK",
                table: "Book",
                newName: "ACCOUNT_ID_FK");

            migrationBuilder.RenameIndex(
                name: "IX_Book_DOCUMENT_ID_FK",
                table: "Book",
                newName: "IX_Book_ACCOUNT_ID_FK");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL_ADDRESS",
                table: "User",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "ACCOUNT_ID_FK",
                table: "User",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "BIRTH_DATE",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FIRST_NAME",
                table: "User",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "MODIFIED_DATE",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SECOND_NAME",
                table: "User",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Account_ACCOUNT_ID_FK",
                table: "Book",
                column: "ACCOUNT_ID_FK",
                principalTable: "Account",
                principalColumn: "ACCOUNT_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
