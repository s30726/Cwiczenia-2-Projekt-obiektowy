using SchoolRental.Models;
using SchoolRental.Models.Equipment;

namespace SchoolRental.Services;

public class ReportService
{
    public string GenerateReport(List<Device> devices, List<Rental> rentals)
    {
        var total = devices.Count;
        var available = devices.Count(d => d.Status == DeviceStatus.Available);
        var rented = devices.Count(d => d.Status == DeviceStatus.Rented);
        var unavailable = devices.Count(d => d.Status == DeviceStatus.Unavailable);
        var overdue = rentals.Count(r => r.IsOverdue);
        
        return $"""
                ===== REPORT =====
                Total devices: {total}
                Available: {available}
                Rented: {rented}
                Unavailable: {unavailable}
                Overdue rentals: {overdue}
                =================
                """;
    }
    
    public string GenerateAvailableDevicesReport(List<Device> devices)
    {
        var availableDevices = devices
            .Where(d => d.Status == DeviceStatus.Available);

        return "===== AVAILABLE DEVICES =====\n" +
               string.Join("\n", availableDevices) +
               "\n=============================";
    }
    
    public string GenerateOverdueRentalsReport(List<Rental> rentals)
    {
        var overdue = rentals.Where(r => r.IsOverdue);

        return "===== OVERDUE RENTALS =====\n" +
               string.Join("\n", overdue) +
               "\n==========================";
    }
}