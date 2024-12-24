using System.ComponentModel.DataAnnotations.Schema;

namespace MudekServer.Models{
[Table("Students")] 
    public class Student
{
    public int Id { get; set; }
    public string Isim { get; set; }
    public string Soyisim { get; set; }
    public string Numara { get; set; }
}

}