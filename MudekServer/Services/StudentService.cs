using Microsoft.EntityFrameworkCore;
using MudekServer;
using MudekServer.Data;
using MudekServer.Models;

public class StudentService
{
    private readonly ApplicationDbContext _context;

    public StudentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        return await _context.Students.ToListAsync();
    }

}
