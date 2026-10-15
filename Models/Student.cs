namespace WestcoastEdukation.Models;

public class Student : Person
{
    public List<Course> Courses { get; set; } = new();
}
