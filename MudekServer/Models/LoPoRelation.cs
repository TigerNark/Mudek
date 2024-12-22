using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudekServer.Models
{
    public class LoPoRelation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("LearningOutcome")]
        public int LearningOutcomeId { get; set; }
        public LearningOutcome LearningOutcome { get; set; }

        public int ProgramOutcome { get; set; } // Program çıktısı (P1-P11)

        public int Score { get; set; } // 0-5 arası değer
    }
}
