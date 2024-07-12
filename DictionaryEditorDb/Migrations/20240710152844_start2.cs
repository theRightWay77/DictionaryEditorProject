using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DictionaryEditorDb.Migrations
{
    /// <inheritdoc />
    public partial class start2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VocabularyItems_Words_TagsValueId",
                table: "VocabularyItems");

            migrationBuilder.DropIndex(
                name: "IX_VocabularyItems_TagsValueId",
                table: "VocabularyItems");

            migrationBuilder.AddColumn<Guid>(
                name: "WordId",
                table: "VocabularyItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyItems_TagsValueId",
                table: "VocabularyItems",
                column: "TagsValueId");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyItems_WordId",
                table: "VocabularyItems",
                column: "WordId");

            migrationBuilder.AddForeignKey(
                name: "FK_VocabularyItems_Words_WordId",
                table: "VocabularyItems",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VocabularyItems_Words_WordId",
                table: "VocabularyItems");

            migrationBuilder.DropIndex(
                name: "IX_VocabularyItems_TagsValueId",
                table: "VocabularyItems");

            migrationBuilder.DropIndex(
                name: "IX_VocabularyItems_WordId",
                table: "VocabularyItems");

            migrationBuilder.DropColumn(
                name: "WordId",
                table: "VocabularyItems");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyItems_TagsValueId",
                table: "VocabularyItems",
                column: "TagsValueId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VocabularyItems_Words_TagsValueId",
                table: "VocabularyItems",
                column: "TagsValueId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
