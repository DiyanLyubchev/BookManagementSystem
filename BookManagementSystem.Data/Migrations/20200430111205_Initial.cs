using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace BookManagementSystem.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BOOK",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    BOOKTITLE = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    DATECREATED = table.Column<DateTime>(type: "DATE", nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERACCOUNT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    FIRSTNAME = table.Column<string>(type: "VARCHAR2(40)", nullable: false),
                    LASTNAME = table.Column<string>(type: "VARCHAR2(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERACCOUNT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AUTHOR",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    AUTHORNAME = table.Column<string>(type: "VARCHAR2(40)", nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    BookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTHOR", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AUTHOR_BOOK_BookId",
                        column: x => x.BookId,
                        principalTable: "BOOK",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BOOKLENDING",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    TAKEDATE = table.Column<DateTime>(type: "DATE", nullable: false),
                    BookId = table.Column<int>(nullable: true),
                    UserAccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOKLENDING", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BOOKLENDING_BOOK_BookId",
                        column: x => x.BookId,
                        principalTable: "BOOK",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BOOKLENDING_USERACCOUNT_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "USERACCOUNT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AUTHOR",
                columns: new[] { "ID", "AUTHORNAME", "BookId", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "Ivan Vazov", null, false },
                    { 2, "Peio Qvorov", null, false },
                    { 3, "Dimcho Debelqnov", null, false }
                });

            migrationBuilder.InsertData(
                table: "BOOK",
                columns: new[] { "ID", "BOOKTITLE", "DATECREATED", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "Pod Igoto", new DateTime(2014, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 2, "Poeziq", new DateTime(2020, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 3, "V polite na Vitosha", new DateTime(2018, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false }
                });

            migrationBuilder.InsertData(
                table: "USERACCOUNT",
                columns: new[] { "ID", "FIRSTNAME", "LASTNAME" },
                values: new object[,]
                {
                    { 1, "Dimitur", "Sokolov" },
                    { 2, "Kaloqn", "Ivanov" },
                    { 3, "Emiliqn", "Nikolov" }
                });

            migrationBuilder.InsertData(
                table: "BOOKLENDING",
                columns: new[] { "ID", "BookId", "TAKEDATE", "UserAccountId" },
                values: new object[] { 3, 3, new DateTime(2020, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "BOOKLENDING",
                columns: new[] { "ID", "BookId", "TAKEDATE", "UserAccountId" },
                values: new object[] { 1, 1, new DateTime(2020, 4, 30, 14, 12, 4, 814, DateTimeKind.Local).AddTicks(8650), 2 });

            migrationBuilder.InsertData(
                table: "BOOKLENDING",
                columns: new[] { "ID", "BookId", "TAKEDATE", "UserAccountId" },
                values: new object[] { 2, 2, new DateTime(2020, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_AUTHOR_BookId",
                table: "AUTHOR",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BOOKLENDING_BookId",
                table: "BOOKLENDING",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BOOKLENDING_UserAccountId",
                table: "BOOKLENDING",
                column: "UserAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUTHOR");

            migrationBuilder.DropTable(
                name: "BOOKLENDING");

            migrationBuilder.DropTable(
                name: "BOOK");

            migrationBuilder.DropTable(
                name: "USERACCOUNT");
        }
    }
}
