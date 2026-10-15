
using WestcoastEdukation.Models;

namespace WestcoastEdukation.Services;

public static class CourseService
{
    public static Course RegisterCourse()
    {
        Course course = new Course();

        Console.Write("Ange kursnummer: ");
        course.CourseNumber = Console.ReadLine() ?? "";

        Console.Write("Ange kursnamn: ");
        course.Title = Console.ReadLine() ?? "";

        
        Console.Write("Ange kursens längd (antal): ");
        int length;

        while (!int.TryParse(Console.ReadLine(), out length) || length <= 0)
        {
            Console.Write("Ange ett positivt heltal: ");
        }

        course.Length = length;

        Console.Write("Ange 1 för dagar eller 2 för veckor: ");
        string durationChoice = Console.ReadLine() ?? "";

        while (durationChoice != "1" && durationChoice != "2")
        {
            Console.Write("Fel val. Ange 1 eller 2: ");
            durationChoice = Console.ReadLine() ?? "";
        }

        if (durationChoice == "1")
        {
            course.DurationType = DurationType.Days;
        }
        else
        {
            course.DurationType = DurationType.Weeks;
        }
        
        Console.Write("Ange startdatum (ÅÅÅÅ-MM-DD): ");
        DateTime startDate;

        while (!DateTime.TryParse(Console.ReadLine(), out startDate))
        {
            Console.Write("Fel datum. Försök igen: ");
        }

        course.StartDate = startDate;

        Console.Write("Ange slutdatum (ÅÅÅÅ-MM-DD): ");
        DateTime endDate;

        while (!DateTime.TryParse(Console.ReadLine(), out endDate)
                || endDate < startDate)
        {
            Console.Write("Ange ett giltigt slutdatum: ");
        }

        course.EndDate = endDate;


        
        Console.Write("Ange 1 för klassrum eller 2 för distans: ");
        string typeChoice = Console.ReadLine() ?? "";

        while (typeChoice != "1" && typeChoice != "2")
        {
            Console.Write("Fel val. Ange 1 eller 2: ");
            typeChoice = Console.ReadLine() ?? "";
        }

        if (typeChoice == "1")
        {
            course.Type = CourseType.Classroom;
        }
        else
        {
            course.Type = CourseType.Distance;
        }



        return course;

    }
}
