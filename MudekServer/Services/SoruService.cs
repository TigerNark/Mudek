using Microsoft.EntityFrameworkCore;
using MudekServer.Data;
using MudekServer.Models;

namespace MudekServer.Services
{
    public class SoruService
    {
        private readonly ApplicationDbContext _context;

        public SoruService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SorulariKaydetAsync(List<Soru> sorular)
        {
            _context.Sorular.AddRange(sorular);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Lesson>> GetDerslerAsync()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task<List<SinavTur>> GetSinavTurleriAsync()
        {
            return await _context.SinavTurleri.ToListAsync();
        }
    }
}
