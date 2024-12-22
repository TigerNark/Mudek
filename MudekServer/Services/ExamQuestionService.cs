using MudekServer.Models;
using Microsoft.EntityFrameworkCore;
using MudekServer.Data;

namespace MudekServer.Services
{
    public class ExamQuestionService
    {
        private readonly ApplicationDbContext _context;

        public ExamQuestionService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Yeni bir ExamQuestion kaydı ekleme
        public async Task<int> AddExamQuestionAsync(ExamQuestion examQuestion)
        {
            _context.ExamQuestions.Add(examQuestion);
            await _context.SaveChangesAsync();
            return examQuestion.Id; // Eklenen kaydın Id'sini döndür
        }

        // Var olan bir ExamQuestion'ı Id ile getirme
        public async Task<ExamQuestion> GetByIdAsync(int id)
        {
            return await _context.ExamQuestions.FindAsync(id);
        }

        // Tüm ExamQuestion kayıtlarını getirme
        public async Task<List<ExamQuestion>> GetAllAsync()
        {
            return await _context.ExamQuestions.ToListAsync();
        }

        // ExamQuestion güncelleme
        public async Task UpdateExamQuestionAsync(ExamQuestion examQuestion)
        {
            _context.ExamQuestions.Update(examQuestion);
            await _context.SaveChangesAsync();
        }

        // ExamQuestion silme
        public async Task DeleteExamQuestionAsync(int id)
        {
            var examQuestion = await _context.ExamQuestions.FindAsync(id);
            if (examQuestion != null)
            {
                _context.ExamQuestions.Remove(examQuestion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
