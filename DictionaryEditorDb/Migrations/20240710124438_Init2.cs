using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DictionaryEditorDb.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vocabulary");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("1d1ed636-5eff-450d-856d-28b20cfac3e5"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("317cf0d7-7981-4857-8f5b-1cfe8df1e931"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("562764bb-8ebc-40f6-b517-381efb6e5e24"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("aaabe949-2a36-4137-a784-aa10b14a9fa8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e1c8ab6d-e05c-4bf2-8287-a5f48ab83549"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("e2cba40c-51fe-42c4-a936-465d38de5c66"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("f53ac2d4-a217-42f1-8dab-0f37a9a51526"));

            migrationBuilder.AddColumn<Guid>(
                name: "VocabularyItemId",
                table: "Words",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VocabularyItemId",
                table: "TagsValues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("51330434-46c7-455b-8836-b47586390250"), "Russian" },
                    { new Guid("c6fbc850-7a63-4b4f-9433-57327afa9ba1"), "Ossetian" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { new Guid("090d25a3-dfb6-48dc-ae66-6bc0c5475d2b"), "часть речи" },
                    { new Guid("200a5a2a-5820-488c-ba7e-c574cd1446fb"), "падеж" },
                    { new Guid("34aa3245-af78-40e2-b8d5-7e700efb3468"), "род" },
                    { new Guid("6fc6cab5-cb9c-497f-87de-0ec6e66b7144"), "число" },
                    { new Guid("c79e4d08-bdf7-4568-a8b0-bea092b7eeae"), "время" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Words_VocabularyItemId",
                table: "Words",
                column: "VocabularyItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyItems_TagsValueId",
                table: "VocabularyItems",
                column: "TagsValueId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_VocabularyItems_VocabularyItemId",
                table: "Words",
                column: "VocabularyItemId",
                principalTable: "VocabularyItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_VocabularyItems_VocabularyItemId",
                table: "Words");

            migrationBuilder.DropTable(
                name: "VocabularyItems");

            migrationBuilder.DropIndex(
                name: "IX_Words_VocabularyItemId",
                table: "Words");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("51330434-46c7-455b-8836-b47586390250"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("c6fbc850-7a63-4b4f-9433-57327afa9ba1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("090d25a3-dfb6-48dc-ae66-6bc0c5475d2b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("200a5a2a-5820-488c-ba7e-c574cd1446fb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("34aa3245-af78-40e2-b8d5-7e700efb3468"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("6fc6cab5-cb9c-497f-87de-0ec6e66b7144"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("c79e4d08-bdf7-4568-a8b0-bea092b7eeae"));

            migrationBuilder.DropColumn(
                name: "VocabularyItemId",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "VocabularyItemId",
                table: "TagsValues");

            migrationBuilder.CreateTable(
                name: "Vocabulary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "IX_Vocabulary_TagsValueId",
                table: "Vocabulary",
                column: "TagsValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Vocabulary_WordId",
                table: "Vocabulary",
                column: "WordId");
        }
    }
}
