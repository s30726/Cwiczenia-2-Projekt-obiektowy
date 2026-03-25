namespace SchoolRental.Models.Users;

public class Employee : User
{
    public string EmployeeNumber { get; set; }

    public Employee(string firstName, string lastName, string employeeNumber) : base(firstName, lastName)
    {
        EmployeeNumber = employeeNumber;
    }

    public override int GetMaxActiveRentals()
    {
        return 5;
    }

    public override string ToString()
    {
        return base.ToString() + $" | {EmployeeNumber}\n";
    }
}