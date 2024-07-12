using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DictionaryEditorDb.Migrations
{
    /// <inheritdoc />
    public partial class start : Migration
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
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VocabularyItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VocabularyItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "VocabularyItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VocabularyItems_TagsValues_TagsValueId",
                        column: x => x.TagsValueId,
                        principalTable: "TagsValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VocabularyItems_Words_TagsValueId",
                        column: x => x.TagsValueId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("3e53afc7-71e5-4dc5-8d6a-87a2ce5031bd"), "Ossetian" },
                    { new Guid("66be7803-143c-4353-91f6-1642b3cab3a1"), "Russian" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("45c21b89-2c3d-46bd-8c51-48e736d9ba7e"), "tense" },
                    { new Guid("80a5341a-431b-49f0-858f-86feccc457b5"), "case" },
                    { new Guid("8403879b-267e-4694-8b1e-f2b31fb058c0"), "number" },
                    { new Guid("c9ecd2db-0a26-4070-927f-71bfb8a80b81"), "gender" },
                    { new Guid("e1260d2a-e7de-4a22-bd57-622ba0bf4c4f"), "partOfSpeech" }
                });

            migrationBuilder.InsertData(
                table: "TagsValues",
                columns: new[] { "Id", "TagId", "Value", "VocabularyItemId" },
                values: new object[,]
                {
                    { new Guid("1c57ae51-646f-4147-a428-fd6bef86c760"), new Guid("c9ecd2db-0a26-4070-927f-71bfb8a80b81"), "female", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("254ea92e-b848-4815-b41b-81dbca1d7ab4"), new Guid("8403879b-267e-4694-8b1e-f2b31fb058c0"), "plural", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("2b87e731-5927-428d-a995-3146160f33ad"), new Guid("c9ecd2db-0a26-4070-927f-71bfb8a80b81"), "male", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("68d5999f-9d0a-4b5e-80ae-35ca860b8781"), new Guid("8403879b-267e-4694-8b1e-f2b31fb058c0"), "single", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("6d1027e4-3540-4ee9-ad67-dd84b0b1e5f2"), new Guid("e1260d2a-e7de-4a22-bd57-622ba0bf4c4f"), "adjective", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("78071fbb-1f19-46a3-a458-e77e906bc4ef"), new Guid("45c21b89-2c3d-46bd-8c51-48e736d9ba7e"), "past", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("a8243201-9fe8-45ff-82d1-211086c049e0"), new Guid("e1260d2a-e7de-4a22-bd57-622ba0bf4c4f"), "adverb", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("b30b749a-35e7-4a7c-8e50-d84c9fcca794"), new Guid("45c21b89-2c3d-46bd-8c51-48e736d9ba7e"), "future", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ce733542-8353-4ab0-8729-7cfdaa621c69"), new Guid("e1260d2a-e7de-4a22-bd57-622ba0bf4c4f"), "Существительное", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("d8e694f5-0d72-4845-be4c-8de15bb5773e"), new Guid("e1260d2a-e7de-4a22-bd57-622ba0bf4c4f"), "verb", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("de073eaf-d3f5-47e3-8f37-59338fe14b2f"), new Guid("c9ecd2db-0a26-4070-927f-71bfb8a80b81"), "middle", new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("f88a7c76-e882-4dce-9024-9f18e911c34a"), new Guid("45c21b89-2c3d-46bd-8c51-48e736d9ba7e"), "present", new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagsValues_TagId",
                table: "TagsValues",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyItems_TagsValueId",
                table: "VocabularyItems",
                column: "TagsValueId",
                unique: true);

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
                name: "VocabularyItems");

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
