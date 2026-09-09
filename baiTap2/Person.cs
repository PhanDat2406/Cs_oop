namespace oop.baiTap2;

public class Person
{
    public string Id { get; init; }
    public string FullName { get; set; }
    public int BirthYear { get; set; }

    public Person(string id, string fullName, int birthYear)
    {
        Id = id;
        FullName = fullName;
        BirthYear = birthYear;
    }

    public int GetAge(int currentYear) => currentYear - BirthYear;
}