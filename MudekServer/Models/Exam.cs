using static MudekServer.Pages.Exam_analysis;

namespace MudekServer.Models{

    public class Exam
{
    public int Id { get; set; }
    public string ExamType { get; set; }  // Örneğin "Vize", "Final" vb.
    public int Percentage { get; set; }
   
   
}

}