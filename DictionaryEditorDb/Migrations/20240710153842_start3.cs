using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DictionaryEditorDb.Migrations
{
    /// <inheritdoc />
    public partial class start3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VocabularyItemId",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "VocabularyItemId",
                table: "TagsValues");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "TagsValues",
                keyColumn: "Id",
                keyValue: new Guid("1c57ae51-646f-4147-a428-fd6bef86c760"),
                column: "VocabularyItemId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "TagsValues",
                keyColumn: "Id",
                keyValue: new Guid("254ea92e-b848-4815-b41b-81dbca1d7ab4"),
                column: "VocabularyItemId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "TagsValues",
                keyColumn: "Id",
                keyValue: new Guid("2b87e731-5927-428d-a995-3146160f33ad"),
                column: "VocabularyItemId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "TagsValues",
                keyColumn: "Id",
                keyValue: new Guid("68d5999f-9d0a-4b5e-80ae-35ca860b8781"),
                column: "VocabularyItemId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "TagsValues",
                keyColumn: "Id",
                keyValue: new Guid("6d1027e4-3540-4ee9-ad67-dd84b0b1e5f2"),
                column: "VocabularyItemId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "TagsValues",
                keyColumn: "Id",
                keyValue: new Guid("78071fbb-1f19-46a3-a458-e77e906bc4ef"),
                column: "VocabularyItemId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "TagsValues",
                keyColumn: "Id",
                keyValue: new Guid("a8243201-9fe8-45ff-82d1-211086c049e0"),
                column: "VocabularyItemId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "TagsValues",
                keyColumn: "Id",
                keyValue: new Guid("b30b749a-35e7-4a7c-8e50-d84c9fcca794"),
                column: "VocabularyItemId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "TagsValues",
                keyColumn: "Id",
                keyValue: new Guid("ce733542-8353-4ab0-8729-7cfdaa621c69"),
                column: "VocabularyItemId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "TagsValues",
                keyColumn: "Id",
                keyValue: new Guid("d8e694f5-0d72-4845-be4c-8de15bb5773e"),
                column: "VocabularyItemId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "TagsValues",
                keyColumn: "Id",
                keyValue: new Guid("de073eaf-d3f5-47e3-8f37-59338fe14b2f"),
                column: "VocabularyItemId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "TagsValues",
                keyColumn: "Id",
                keyValue: new Guid("f88a7c76-e882-4dce-9024-9f18e911c34a"),
                column: "VocabularyItemId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
