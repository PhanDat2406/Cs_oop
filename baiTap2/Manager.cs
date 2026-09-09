namespace oop.baiTap2;


public sealed class Manager : Employee
{
    public decimal ResponsibilityAllowance { get; set; }

    public Manager(string id, string fullName, int birthYear, decimal baseSalary, decimal allowance)
        : base(id, fullName, birthYear, baseSalary)
    {
        ResponsibilityAllowance = allowance;
    }

    public override decimal CalculateIncome() => BaseSalary + ResponsibilityAllowance;
}