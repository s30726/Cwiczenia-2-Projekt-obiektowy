using SchoolRental.Models.Users;
using  SchoolRental.Models.Equipment;

namespace SchoolRental.Models;

public class Rental
{
public Guid Id { get; private set; }
public User User { get; private set; }
public Device Device { get; private set; }

public DateTime RentalDate { get; private set; }
public DateTime? ReturnDate { get; private set; }
public DateTime RentalEndDate { get; private set; }

public decimal Penalty { get; private set; }

public bool IsReturned => ReturnDate.HasValue;
public bool IsOverdue => !IsReturned && RentalEndDate < DateTime.Now;

public Rental(User user, Device device, int rentalDays)
{
    Id = Guid.NewGuid();
    User = user;
    Device = device;
    RentalDate = DateTime.Now;
    RentalEndDate = RentalDate.AddDays(rentalDays);
}

public void Return(decimal penalty)
{
    ReturnDate = DateTime.Now;
    Penalty = penalty;
}

public override string ToString()
{
    return $"Id: {Id} | User: {User.FirstName} {User.LastName} | Device:  {Device.Name} | Due: {RentalEndDate} | Returned: {ReturnDate} | Penalty: {Penalty}\n";
}
}