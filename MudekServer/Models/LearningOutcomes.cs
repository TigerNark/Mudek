using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudekServer.Models
{
    public class LearningOutcome
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public string Description { get; set; } // Öğrenim çıktısının açıklaması

        [ForeignKey("Lesson")]
        public string CourseCode { get; set; } // Lesson ile ilişki

        public Lesson Lesson { get; set; }

        // LoPoRelation ile ilişkisi
        public List<LoPoRelation> LoPoRelations { get; set; }
    }
}
