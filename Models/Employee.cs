namespace WestcoastEdukation.Models;

public class Employee : Person
{
    public DateTime EmploymentDate { get; set; }

    public string KnowledgeArea { get; set; } = "";

    public override string ToString()
    {
        return base.ToString() +
               $", kunskapsområde: {KnowledgeArea}" +
               $", anställningsdatum: {EmploymentDate:yyyy-MM-dd}";
    }
}

