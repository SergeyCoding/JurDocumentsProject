using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JurDocs.DbModel.Migrations
{
    /// <inheritdoc />
    public partial class Table_JurDocLetter_Add_ProjectId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "JurDocLetter",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "JurDocLetter");
        }
    }
}
