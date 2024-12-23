using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudekServer.Migrations
{
    /// <inheritdoc />
    public partial class SinavTurDatabaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SinavTurId",
                table: "SinavTurleri",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SinavTurId",
                table: "SinavTurleri");
        }
    }
}
