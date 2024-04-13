using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JurDocs.DbModel.Migrations
{
    /// <inheritdoc />
    public partial class table_Project_makeNameUniq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_JurDocProject_Name",
                table: "JurDocProject",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JurDocProject_Name",
                table: "JurDocProject");
        }
    }
}
