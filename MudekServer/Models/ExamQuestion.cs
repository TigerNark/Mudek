using MudekServer.Models;

namespace MudekServer{

public class ExamQuestion
{
    public int Id { get; set; }
    public string QuestionText { get; set; }
    public int Points { get; set; }  // Soru puanı
    public List<LearningOutcome> LearningOutcomes { get; set; }  // İlişkilendirilen öğrenim çıktıları
    

}
}