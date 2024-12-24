namespace MudekServer.Models
{
    public class StudentScore
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int QuestionNumber { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public string DersId { get; set; }
        public int SinavTuruId { get; set; }
    }
}
