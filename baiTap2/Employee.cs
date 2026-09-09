
namespace oop.baiTap2;

public class Employee : Person
{
    public decimal BaseSalary { get; set; }

    public Employee(string id, string fullName, int birthYear, decimal baseSalary)
        : base(id, fullName, birthYear)
    {
        BaseSalary = baseSalary;
    }

    public virtual decimal CalculateIncome() => BaseSalary;
}