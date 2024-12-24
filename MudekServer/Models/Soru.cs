namespace MudekServer.Models
{
    public class Soru
    {
        public int Id { get; set; }
        public string DersId { get; set; }
        public int SinavTuruId { get; set; }
        public int SinavYuzdesi { get; set; }
        public int SoruNumarasi { get; set; }
        public int Puan { get; set; }
        public List<string> OgrenimCiktilari { get; set; } = new List<string>();
    }
}
