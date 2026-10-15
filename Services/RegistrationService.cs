
using WestcoastEdukation.Models;

namespace WestcoastEdukation.Services;

public static class RegistrationService
{
    public static void RegisterPerson(Person person)
    {
        Console.Write("Ange förnamn: ");
        person.FirstName = Console.ReadLine() ?? "";

        Console.Write("Ange efternamn: ");
        person.LastName = Console.ReadLine() ?? "";

        Console.Write("Ange telefonnummer: ");
        person.Phone = Console.ReadLine() ?? "";

        Console.Write("Ange email: ");
        person.Email = Console.ReadLine() ?? "";

        Console.Write("Ange personnummer: ");
        person.PersonalNumber = Console.ReadLine() ?? "";

        Console.Write("Ange adress: ");
        person.Address = Console.ReadLine() ?? "";

        Console.Write("Ange postnummer: ");
        person.PostalCode = Console.ReadLine() ?? "";

        Console.Write("Ange ort: ");
        person.City = Console.ReadLine() ?? "";
    }
    
    public static void RegisterEmployee(Employee employee)
    {
        RegisterPerson(employee);

        Console.Write("Ange kunskapsområde: ");
        employee.KnowledgeArea = Console.ReadLine() ?? "";

        Console.Write("Ange anställningsdatum (ÅÅÅÅ-MM-DD): ");
        DateTime employmentDate;

        while (!DateTime.TryParse(Console.ReadLine(), out employmentDate))
        {
            Console.Write("Felaktigt datum. Försök igen: ");
        }

        employee.EmploymentDate = employmentDate;
    }

}
