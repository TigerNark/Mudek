﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MudekServer.Data;

#nullable disable

namespace MudekServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241222114755_UpdateStudentExamOutcomeExamQuestionRelationship")]
    partial class UpdateStudentExamOutcomeExamQuestionRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MudekServer.ExamQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ExamId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("ExamQuestions");
                });

            modelBuilder.Entity("MudekServer.Models.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ExamType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Percentage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("MudekServer.Models.LearningOutcome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<int?>("ExamQuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseCode");

                    b.HasIndex("ExamQuestionId");

                    b.ToTable("LearningOutcomes", (string)null);
                });

            modelBuilder.Entity("MudekServer.Models.Lesson", b =>
                {
                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("LessonId");

                    b.Property<int>("AKTS")
                        .HasColumnType("int")
                        .HasColumnName("AKTS");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Lesson");

                    b.Property<string>("GroupCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("GroupCode");

                    b.Property<bool>("IsMandatory")
                        .HasColumnType("bit")
                        .HasColumnName("Mandatory");

                    b.HasKey("CourseCode")
                        .HasName("PK_Lessons");

                    b.ToTable("Lessons", (string)null);
                });

            modelBuilder.Entity("MudekServer.Models.LoPoRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LearningOutcomeId")
                        .HasColumnType("int");

                    b.Property<int>("ProgramOutcome")
                        .HasColumnType("int")
                        .HasColumnName("ProgramOutcome");

                    b.Property<int>("Score")
                        .HasColumnType("int")
                        .HasColumnName("Score");

                    b.HasKey("Id");

                    b.HasIndex("LearningOutcomeId");

                    b.ToTable("LoPoRelations", (string)null);
                });

            modelBuilder.Entity("MudekServer.Models.ProgramOutcomes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LessonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("P1")
                        .HasColumnType("int");

                    b.Property<int>("P10")
                        .HasColumnType("int");

                    b.Property<int>("P11")
                        .HasColumnType("int");

                    b.Property<int>("P2")
                        .HasColumnType("int");

                    b.Property<int>("P3")
                        .HasColumnType("int");

                    b.Property<int>("P4")
                        .HasColumnType("int");

                    b.Property<int>("P5")
                        .HasColumnType("int");

                    b.Property<int>("P6")
                        .HasColumnType("int");

                    b.Property<int>("P7")
                        .HasColumnType("int");

                    b.Property<int>("P8")
                        .HasColumnType("int");

                    b.Property<int>("P9")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonId")
                        .IsUnique();

                    b.ToTable("ProgramOutcomes", (string)null);
                });

            modelBuilder.Entity("MudekServer.Models.SinavTur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SinavTurleri");
                });

            modelBuilder.Entity("MudekServer.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Isim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numara")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyisim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("MudekServer.Models.StudentExamOutcome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<int>("ExamQuestionId")
                        .HasColumnType("int");

                    b.PrimitiveCollection<string>("SelectedLearningOutcomes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("ExamQuestionId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentExamOutcomes");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("MudekServer.ExamQuestion", b =>
                {
                    b.HasOne("MudekServer.Models.Exam", null)
                        .WithMany("Questions")
                        .HasForeignKey("ExamId");
                });

            modelBuilder.Entity("MudekServer.Models.LearningOutcome", b =>
                {
                    b.HasOne("MudekServer.Models.Lesson", "Lesson")
                        .WithMany("LearningOutcomes")
                        .HasForeignKey("CourseCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MudekServer.ExamQuestion", null)
                        .WithMany("LearningOutcomes")
                        .HasForeignKey("ExamQuestionId");

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("MudekServer.Models.LoPoRelation", b =>
                {
                    b.HasOne("MudekServer.Models.LearningOutcome", "LearningOutcome")
                        .WithMany("LoPoRelations")
                        .HasForeignKey("LearningOutcomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LearningOutcome");
                });

            modelBuilder.Entity("MudekServer.Models.ProgramOutcomes", b =>
                {
                    b.HasOne("MudekServer.Models.Lesson", "Lesson")
                        .WithOne("ProgramOutcomes")
                        .HasForeignKey("MudekServer.Models.ProgramOutcomes", "LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("MudekServer.Models.StudentExamOutcome", b =>
                {
                    b.HasOne("MudekServer.Models.Exam", "Exam")
                        .WithMany("StudentExamOutcomes")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MudekServer.ExamQuestion", "ExamQuestion")
                        .WithMany("StudentExamOutcomes")
                        .HasForeignKey("ExamQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MudekServer.Models.Student", "Student")
                        .WithMany("StudentExamOutcomes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("ExamQuestion");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("MudekServer.ExamQuestion", b =>
                {
                    b.Navigation("LearningOutcomes");

                    b.Navigation("StudentExamOutcomes");
                });

            modelBuilder.Entity("MudekServer.Models.Exam", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("StudentExamOutcomes");
                });

            modelBuilder.Entity("MudekServer.Models.LearningOutcome", b =>
                {
                    b.Navigation("LoPoRelations");
                });

            modelBuilder.Entity("MudekServer.Models.Lesson", b =>
                {
                    b.Navigation("LearningOutcomes");

                    b.Navigation("ProgramOutcomes")
                        .IsRequired();
                });

            modelBuilder.Entity("MudekServer.Models.Student", b =>
                {
                    b.Navigation("StudentExamOutcomes");
                });
#pragma warning restore 612, 618
        }
    }
}
