using Microsoft.EntityFrameworkCore;
using MudekServer.Models;

namespace MudekServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSet'ler
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<ProgramOutcomes> ProgramOutcomes { get; set; }
        public DbSet<LearningOutcome> LearningOutcomes { get; set; }
        public DbSet<LoPoRelation> LoPoRelations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Soru> Sorular { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }

        public DbSet<SinavTur> SinavTurleri { get; set; }  // SinavTur tablosu
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Lessons tablosu
            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("Lessons");
                entity.HasKey(l => l.CourseCode).HasName("PK_Lessons");
                entity.Property(l => l.CourseCode).HasColumnName("LessonId").IsRequired();
                entity.Property(l => l.CourseName).HasColumnName("Lesson").IsRequired();
                entity.Property(l => l.IsMandatory).HasColumnName("Mandatory").IsRequired();
                entity.Property(l => l.GroupCode).HasColumnName("GroupCode");
                entity.Property(l => l.AKTS).HasColumnName("AKTS").IsRequired();
            });

            // ProgramOutcomes tablosu
            modelBuilder.Entity<ProgramOutcomes>(entity =>
            {
                entity.ToTable("ProgramOutcomes");
                entity.HasKey(p => p.Id);

                // Lesson ile one-to-one ilişki
                entity.HasOne(p => p.Lesson)
                      .WithOne(l => l.ProgramOutcomes)
                      .HasForeignKey<ProgramOutcomes>(p => p.LessonId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // LearningOutcomes tablosu
            modelBuilder.Entity<LearningOutcome>(entity =>
            {
                entity.ToTable("LearningOutcomes");
                entity.HasKey(lo => lo.Id);

                entity.Property(lo => lo.Description)
                      .HasColumnName("Description")
                      .IsRequired();

                // Lesson ile one-to-many ilişki
                entity.HasOne(lo => lo.Lesson)
                      .WithMany(l => l.LearningOutcomes)
                      .HasForeignKey(lo => lo.CourseCode)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // LoPoRelations tablosu
            modelBuilder.Entity<LoPoRelation>(entity =>
            {
                entity.ToTable("LoPoRelations");
                entity.HasKey(lp => lp.Id);

                // LearningOutcome ile ilişki
                entity.HasOne(lp => lp.LearningOutcome)
                      .WithMany(lo => lo.LoPoRelations)
                      .HasForeignKey(lp => lp.LearningOutcomeId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(lp => lp.ProgramOutcome)
                      .HasColumnName("ProgramOutcome")
                      .IsRequired();

                entity.Property(lp => lp.Score)
                      .HasColumnName("Score")
                      .IsRequired();
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users"); // Users tablosunu belirtiyoruz
                entity.HasKey(u => u.Id); // Id, kullanıcıyı benzersiz olarak tanımlar
                entity.Property(u => u.Email).IsRequired(); // E-posta zorunlu
                entity.Property(u => u.Password).IsRequired(); // Parola zorunlu
            });

        }
    }
}
public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } // Gerçek uygulamalarda şifrelerin hash'lenmesi gerektiğini unutmayın
}