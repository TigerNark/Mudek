// SinavTurService.cs (Veritabanından veri çekmek için)
using Microsoft.EntityFrameworkCore;
using MudekServer.Data;
using MudekServer.Models;

namespace MudekServer.Services
{
    public class SinavTurService
    {
        private readonly ApplicationDbContext _context;

        public SinavTurService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SinavTur>> GetSinavTurleriAsync()
        {
            return await _context.SinavTurleri.ToListAsync();
        }
    }
}
