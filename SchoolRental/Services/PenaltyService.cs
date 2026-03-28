using SchoolRental.Interfaces;
using SchoolRental.Models;

namespace SchoolRental.Services;

public class PenaltyService : IPenaltyPolicy
{
    private const int DailyPenalty = 100;

    public decimal CalculatePenalty(Rental rental)
    {
        if (rental.ReturnDate <= rental.RentalEndDate)
            return 0;
        int daysLate = (rental.ReturnDate.Value - rental.RentalEndDate).Days;
        return daysLate *  DailyPenalty;
    }
}