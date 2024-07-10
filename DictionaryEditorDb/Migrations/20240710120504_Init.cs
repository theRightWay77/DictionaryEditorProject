using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DictionaryEditorDb.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TranslationsAndExamples",
                columns: table => new
                {
                    Word1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Word2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Example1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Example2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationsAndExamples", x => new { x.Word1Id, x.Word2Id });
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagsValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagsValues_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vocabulary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vocabulary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vocabulary_TagsValues_TagsValueId",
                        column: x => x.TagsValueId,
                        principalTable: "TagsValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vocabulary_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("1d1ed636-5eff-450d-856d-28b20cfac3e5"), "Ossetian" },
                    { new Guid("317cf0d7-7981-4857-8f5b-1cfe8df1e931"), "Russian" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("562764bb-8ebc-40f6-b517-381efb6e5e24"), "время" },
                    { new Guid("aaabe949-2a36-4137-a784-aa10b14a9fa8"), "число" },
                    { new Guid("e1c8ab6d-e05c-4bf2-8287-a5f48ab83549"), "род" },
                    { new Guid("e2cba40c-51fe-42c4-a936-465d38de5c66"), "падеж" },
                    { new Guid("f53ac2d4-a217-42f1-8dab-0f37a9a51526"), "часть речи" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagsValues_TagId",
                table: "TagsValues",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Vocabulary_TagsValueId",
                table: "Vocabulary",
                column: "TagsValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Vocabulary_WordId",
                table: "Vocabulary",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_LanguageId",
                table: "Words",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TranslationsAndExamples");

            migrationBuilder.DropTable(
                name: "Vocabulary");

            migrationBuilder.DropTable(
                name: "TagsValues");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
