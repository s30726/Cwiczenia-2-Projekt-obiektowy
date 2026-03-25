namespace SchoolRental.Models.Users;

public abstract class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get;  set; }
    
    protected  User(string firstName, string lastName)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
    }

    public abstract int GetMaxActiveRentals();

    public override string ToString()
    {
        return $"Id: {Id} | {FirstName} {LastName}";
    }
}