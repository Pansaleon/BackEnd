using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBAPIBackend.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Clases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Clases",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
