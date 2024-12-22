using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudekServer.Models
{
    public class ProgramOutcomes
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [ForeignKey("Lesson")]
        public string LessonId { get; set; } // Lesson ile ilişki

        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }
        public int P4 { get; set; }
        public int P5 { get; set; }
        public int P6 { get; set; }
        public int P7 { get; set; }
        public int P8 { get; set; }
        public int P9 { get; set; }
        public int P10 { get; set; }
        public int P11 { get; set; }

        public Lesson Lesson { get; set; }
    }
}
