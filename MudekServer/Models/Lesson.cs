using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MudekServer.Models
{
    public class Lesson
    {
        [Key] 
        public string CourseCode { get; set; } // Primary Key (LessonId)

        [Required]
        public string CourseName { get; set; }

        public bool IsMandatory { get; set; }  // Zorunlu mu, seçmeli mi?
        
        public string GroupCode { get; set; }

        public int AKTS { get; set; }
        

        // ProgramOutcomes ile One-to-One ilişki
        public ProgramOutcomes ProgramOutcomes { get; set; }

        // LearningOutcomes ile One-to-Many ilişki
        public List<LearningOutcome> LearningOutcomes { get; set; } = new List<LearningOutcome>();
        
    }
}
