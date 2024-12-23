using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudekServer.Migrations
{
    /// <inheritdoc />
    public partial class SoruDatabaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SinavYuzdesi",
                table: "Sorular",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SinavYuzdesi",
                table: "Sorular");
        }
    }
}
