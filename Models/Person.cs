using WestcoastEdukation.Interfaces;

namespace WestcoastEdukation.Models;

public class Person : IPersonInfo
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Phone { get; set; } = "";
    public string PersonalNumber { get; set; } = "";
    public string Address { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string City { get; set; } = "";
    public string Email { get; set; } = "";
    public override string ToString()
    {
       return $"{FirstName} {LastName}, telefon: {Phone}, email: {Email}, adress: {Address}, {PostalCode} {City}";

    }

    public string GetFullName()
    {
        return FirstName + " " + LastName;
    }
}