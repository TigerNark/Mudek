using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudekServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudentExamOutcomeExamQuestionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Exam_ExamId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_LearningOutcomes_ExamQuestion_ExamQuestionId",
                table: "LearningOutcomes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamOutcomes_ExamQuestion_ExamQuestionId",
                table: "StudentExamOutcomes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamOutcomes_Exam_ExamId",
                table: "StudentExamOutcomes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamQuestion",
                table: "ExamQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exam",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "StudentExamOutcomes");

            migrationBuilder.RenameTable(
                name: "ExamQuestion",
                newName: "ExamQuestions");

            migrationBuilder.RenameTable(
                name: "Exam",
                newName: "Exams");

            migrationBuilder.RenameIndex(
                name: "IX_ExamQuestion_ExamId",
                table: "ExamQuestions",
                newName: "IX_ExamQuestions_ExamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamQuestions",
                table: "ExamQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Exams_ExamId",
                table: "ExamQuestions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningOutcomes_ExamQuestions_ExamQuestionId",
                table: "LearningOutcomes",
                column: "ExamQuestionId",
                principalTable: "ExamQuestions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamOutcomes_ExamQuestions_ExamQuestionId",
                table: "StudentExamOutcomes",
                column: "ExamQuestionId",
                principalTable: "ExamQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamOutcomes_Exams_ExamId",
                table: "StudentExamOutcomes",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Exams_ExamId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_LearningOutcomes_ExamQuestions_ExamQuestionId",
                table: "LearningOutcomes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamOutcomes_ExamQuestions_ExamQuestionId",
                table: "StudentExamOutcomes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamOutcomes_Exams_ExamId",
                table: "StudentExamOutcomes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamQuestions",
                table: "ExamQuestions");

            migrationBuilder.RenameTable(
                name: "Exams",
                newName: "Exam");

            migrationBuilder.RenameTable(
                name: "ExamQuestions",
                newName: "ExamQuestion");

            migrationBuilder.RenameIndex(
                name: "IX_ExamQuestions_ExamId",
                table: "ExamQuestion",
                newName: "IX_ExamQuestion_ExamId");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "StudentExamOutcomes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exam",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamQuestion",
                table: "ExamQuestion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Exam_ExamId",
                table: "ExamQuestion",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningOutcomes_ExamQuestion_ExamQuestionId",
                table: "LearningOutcomes",
                column: "ExamQuestionId",
                principalTable: "ExamQuestion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamOutcomes_ExamQuestion_ExamQuestionId",
                table: "StudentExamOutcomes",
                column: "ExamQuestionId",
                principalTable: "ExamQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamOutcomes_Exam_ExamId",
                table: "StudentExamOutcomes",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
