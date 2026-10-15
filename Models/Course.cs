namespace WestcoastEdukation.Models;
using System.Text.Json.Serialization;

public class Course
{
    public string CourseNumber { get; set; } = "";
    public string Title { get; set; } = "";
    public int Length { get; set; }
    public DurationType DurationType { get; set;}
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public CourseType Type { get; set;}

    [JsonIgnore]
    public Teacher? Teacher { get; set;}

    public string TeacherPersonalNumber { get; set; } = "";

    [JsonIgnore]
    public List<Student> Students { get; set; } = new();

    public List<string> StudentPersonalNumber { get; set; } = new();

    public override string ToString()
    {
        string teacherName = Teacher == null
            ? "Ingen lärare tilldelad"
            : $"{Teacher.FirstName} {Teacher.LastName}";
        
        return $"{CourseNumber} - {Title}, " +
               $"Längd: {Length} {DurationType}, " +
               $"Startdatum : {StartDate:yyyy-MM-dd}, " +
               $"Slutdatum: {EndDate:yyyy-MM-dd}, " +
               $"Undervisningsform: {Type}, " +
               $"Lärare: {teacherName}";
    }
}

