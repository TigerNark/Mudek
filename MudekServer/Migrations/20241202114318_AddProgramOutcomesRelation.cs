using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudekServer.Migrations
{
    /// <inheritdoc />
    public partial class AddProgramOutcomesRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Lesson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mandatory = table.Column<bool>(type: "bit", nullable: false),
                    GroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AKTS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonId);
                });

            migrationBuilder.CreateTable(
                name: "ProgramOutcomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    P1 = table.Column<int>(type: "int", nullable: false),
                    P2 = table.Column<int>(type: "int", nullable: false),
                    P3 = table.Column<int>(type: "int", nullable: false),
                    P4 = table.Column<int>(type: "int", nullable: false),
                    P5 = table.Column<int>(type: "int", nullable: false),
                    P6 = table.Column<int>(type: "int", nullable: false),
                    P7 = table.Column<int>(type: "int", nullable: false),
                    P8 = table.Column<int>(type: "int", nullable: false),
                    P9 = table.Column<int>(type: "int", nullable: false),
                    P10 = table.Column<int>(type: "int", nullable: false),
                    P11 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramOutcomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramOutcomes_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramOutcomes_LessonId",
                table: "ProgramOutcomes",
                column: "LessonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramOutcomes");

            migrationBuilder.DropTable(
                name: "Lessons");
        }
    }
}
