using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRapp.Migrations
{
    /// <inheritdoc />
    public partial class RenamedPersonIdForForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Persons",
                newName: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Persons",
                newName: "Id");
        }
    }
}
