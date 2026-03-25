using SchoolRental.Models;

namespace SchoolRental.Interfaces;

public interface IPenaltyPolicy
{
    decimal CalculatePenalty(Rental rental);
    
}