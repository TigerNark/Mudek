using MudekServer.Models;
using MudekServer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudekServer.Services
{
    public class LessonService
    {
        private readonly ApplicationDbContext _context;

        // Constructor
        public LessonService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Mevcut dersleri veritabanından döndüren fonksiyon
        public async Task<List<Lesson>> GetLessons(bool includeProgramOutcomes = true)
        {
            if (includeProgramOutcomes)
            {
                return await _context.Lessons
                    .Include(l => l.ProgramOutcomes)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else
            {
                return await _context.Lessons
                    .AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<Lesson> GetLessonByCodeAsync(string courseCode)
        {
            return await _context.Lessons
                .Include(l => l.LearningOutcomes)
                .FirstOrDefaultAsync(l => l.CourseCode == courseCode);
        }
        // Yeni ders ekleyen fonksiyon
        public async Task AddLesson(Lesson lesson)
        {
            try
            {
                _context.Lessons.Add(lesson);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Hata loglama veya özel hata işleme yapılabilir
                throw new InvalidOperationException("Ders eklenirken bir hata oluştu.", ex);
            }
        }


        // Dersin ProgramOutcomes bilgilerini güncelleme fonksiyonu
        public async Task UpdateLessonProgramOutcomes(Lesson lesson)
        {
            try
            {
                // Veritabanında ilgili dersin program çıktısı ortalamalarını güncelleme
                var existingLesson = await _context.Lessons
                    .Include(l => l.ProgramOutcomes) // ProgramOutcomes ilişkisini dahil et
                    .FirstOrDefaultAsync(l => l.CourseCode == lesson.CourseCode);

                if (existingLesson != null)
                {
                    // ProgramOutcomes null ise yeni bir örnek oluştur
                    existingLesson.ProgramOutcomes ??= new ProgramOutcomes();

                    // Program çıktılarının güncellenmesi
                    existingLesson.ProgramOutcomes.P1 = lesson.ProgramOutcomes.P1;
                    existingLesson.ProgramOutcomes.P2 = lesson.ProgramOutcomes.P2;
                    existingLesson.ProgramOutcomes.P3 = lesson.ProgramOutcomes.P3;
                    existingLesson.ProgramOutcomes.P4 = lesson.ProgramOutcomes.P4;
                    existingLesson.ProgramOutcomes.P5 = lesson.ProgramOutcomes.P5;
                    existingLesson.ProgramOutcomes.P6 = lesson.ProgramOutcomes.P6;
                    existingLesson.ProgramOutcomes.P7 = lesson.ProgramOutcomes.P7;
                    existingLesson.ProgramOutcomes.P8 = lesson.ProgramOutcomes.P8;
                    existingLesson.ProgramOutcomes.P9 = lesson.ProgramOutcomes.P9;
                    existingLesson.ProgramOutcomes.P10 = lesson.ProgramOutcomes.P10;
                    existingLesson.ProgramOutcomes.P11 = lesson.ProgramOutcomes.P11;

                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new InvalidOperationException("Ders bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                // Hata loglama veya özel hata işleme yapılabilir
                throw new InvalidOperationException("Program çıktıları güncellenirken bir hata oluştu.", ex);
            }
        }
        public async Task<Lesson> GetLessonWithLoPoRelations(string courseCode)
    {
        return await _context.Lessons
            .Include(l => l.LearningOutcomes)
            .ThenInclude(lo => lo.LoPoRelations)
            .FirstOrDefaultAsync(l => l.CourseCode == courseCode);
    }
    }
}
