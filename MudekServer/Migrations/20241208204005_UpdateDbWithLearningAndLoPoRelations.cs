using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudekServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbWithLearningAndLoPoRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LearningOutcomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningOutcomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningOutcomes_Lessons_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoPoRelations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LearningOutcomeId = table.Column<int>(type: "int", nullable: false),
                    ProgramOutcome = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoPoRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoPoRelations_LearningOutcomes_LearningOutcomeId",
                        column: x => x.LearningOutcomeId,
                        principalTable: "LearningOutcomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearningOutcomes_CourseCode",
                table: "LearningOutcomes",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_LoPoRelations_LearningOutcomeId",
                table: "LoPoRelations",
                column: "LearningOutcomeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoPoRelations");

            migrationBuilder.DropTable(
                name: "LearningOutcomes");
        }
    }
}
