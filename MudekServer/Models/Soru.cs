namespace MudekServer.Models
{
    public class Soru
    {
        public int SoruNumarasi { get; set; }
        public int Puan { get; set; }
        public List<LearningOutcome> SecilenOgrenimCiktilari { get; set; } = new List<LearningOutcome>(); // Öğrenim çıktıları
        public object StudentExamOutcomes { get; internal set; }
    }

}
