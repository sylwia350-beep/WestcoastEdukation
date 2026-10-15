namespace WestcoastEdukation.Models;

public class Teacher : Employee
{
    public List<Course> Courses { get; set; } = new();

   
}


