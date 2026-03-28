using SchoolRental.Interfaces;
using SchoolRental.Models;
using SchoolRental.Models.Equipment;
using SchoolRental.Models.Users;

namespace SchoolRental.Services;

public class RentalService : IRentalService

{
    private readonly List<Rental> _rentals = new();
    private readonly IPenaltyPolicy _penaltyPolicy;

    public RentalService(IPenaltyPolicy penaltyPolicy)
    {
        _penaltyPolicy = penaltyPolicy;
    }

    public Rental RentDevice(User user, Device device, int days)
    {
        if (device.Status != DeviceStatus.Available)
            throw new Exception("Device is not available");
        
        int activeCount = GetActiveRentals(user).Count;
        
        if (activeCount >= user.GetMaxActiveRentals())
            throw new Exception("User exceeds maximum allowed rentals");
        
        var rental = new Rental(user, device, days);
        
        device.MarkAsRented();
        _rentals.Add(rental);
        
        return rental;
    }

    public void ReturnDevice(Rental rental)
    {
        if (rental.IsReturned)
            throw new Exception("Already returned");

        rental.MarkAsReturned();
        rental.Device.MarkAsAvailable();
        var penalty = _penaltyPolicy.CalculatePenalty(rental);
        rental.ApplyPenalty(penalty);
        
    }

    public List<Rental> GetAllRentals()
    {
        return _rentals;
    }

    public List<Rental> GetActiveRentals(User user)
    {
        return  _rentals.Where(r => r.User == user && !r.IsReturned).ToList();
    }

    public List<Rental> GetOverdueRentals()
    {
        return _rentals.Where(r => r.IsOverdue).ToList();
    }
}