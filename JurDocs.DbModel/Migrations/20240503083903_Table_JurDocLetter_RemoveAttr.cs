using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JurDocs.DbModel.Migrations
{
    /// <inheritdoc />
    public partial class Table_JurDocLetter_RemoveAttr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JurDocLetterAttributes_JurDocLetter_JurDocLetterId",
                table: "JurDocLetterAttributes");

            migrationBuilder.DropIndex(
                name: "IX_JurDocLetterAttributes_JurDocLetterId",
                table: "JurDocLetterAttributes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_JurDocLetterAttributes_JurDocLetterId",
                table: "JurDocLetterAttributes",
                column: "JurDocLetterId");

            migrationBuilder.AddForeignKey(
                name: "FK_JurDocLetterAttributes_JurDocLetter_JurDocLetterId",
                table: "JurDocLetterAttributes",
                column: "JurDocLetterId",
                principalTable: "JurDocLetter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
