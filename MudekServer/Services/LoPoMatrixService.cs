using Microsoft.EntityFrameworkCore;
using MudekServer.Data;
using MudekServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudekServer.Services
{
    public class LoPoMatrixService
    {
        private readonly ApplicationDbContext _context;

        public LoPoMatrixService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> SaveLoPOMatrix(string courseCode, Dictionary<string, int> loPoValues)
        {
            try
            {
                // Önce bu ders için mevcut LoPoRelation'ları temizle
                var existingRelations = await _context.LoPoRelations
                    .Include(r => r.LearningOutcome)
                    .Where(r => r.LearningOutcome.CourseCode == courseCode)
                    .ToListAsync();

                _context.LoPoRelations.RemoveRange(existingRelations);

                // LearningOutcome listesini al
                var learningOutcomesList = await _context.LearningOutcomes
                    .Where(lo => lo.CourseCode == courseCode)
                    .ToListAsync();

                var loPoRelations = new List<LoPoRelation>();

                // LoPo matrisindeki her hücreyi işle
                for (int i = 0; i < learningOutcomesList.Count; i++)
                {
                    for (int j = 1; j <= 11; j++)
                    {
                        var key = $"P{j}Ö{i + 1}";
                        var score = loPoValues.ContainsKey(key) ? loPoValues[key] : 0;

                        if (score > 0) // Eğer score 0'dan büyükse, kaydet
                        {
                            loPoRelations.Add(new LoPoRelation
                            {
                                LearningOutcomeId = learningOutcomesList[i].Id,
                                ProgramOutcome = j,
                                Score = score
                            });
                        }
                    }
                }

                // Veritabanına kaydet
                if (loPoRelations.Any())
                {
                    _context.LoPoRelations.AddRange(loPoRelations);
                    await _context.SaveChangesAsync();
                }

                return "LoPo matrisi başarıyla kaydedildi.";
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama yapılabilir
                return $"LoPo matrisi kaydetme işlemi sırasında bir hata oluştu: {ex.Message}";
            }
        }

        // İsteğe bağlı: Bir dersin mevcut LoPoRelation verilerini alma metodu
        public async Task<Dictionary<string, int>> GetLoPOMatrixValues(string courseCode)
        {
            var loPoValues = new Dictionary<string, int>();

            var learningOutcomes = await _context.LearningOutcomes
                .Include(lo => lo.LoPoRelations)
                .Where(lo => lo.CourseCode == courseCode)
                .ToListAsync();

            foreach (var outcome in learningOutcomes)
            {
                var outcomeIndex = learningOutcomes.IndexOf(outcome) + 1;
                foreach (var relation in outcome.LoPoRelations)
                {
                    var key = $"P{relation.ProgramOutcome}Ö{outcomeIndex}";
                    loPoValues[key] = relation.Score;
                }
            }

            return loPoValues;
        }
    }
}