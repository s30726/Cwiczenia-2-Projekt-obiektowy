using SchoolRental.Models;
using SchoolRental.Models.Equipment;
using SchoolRental.Models.Users;

namespace SchoolRental.Interfaces;

public interface IRentalService
{
    Rental RentDevice(User user, Device device, int days);
    void ReturnDevice(Rental rental);
    
    List<Rental> GetActiveRentals(User user);
    List<Rental> GetOverdueRentals();
    
}