namespace SchoolRental.Models.Users;

public class Student : User

{
    public string StudentNumber { get; set; }

    public Student(string firstName, string lastName, string studentNumber) : base(firstName, lastName)
    {
        StudentNumber = studentNumber;
    }

    public override int GetMaxActiveRentals()
    {
        return 2;
    }

    public override string ToString()
    {
        return base.ToString() + $" | {StudentNumber}\n";
    }
}