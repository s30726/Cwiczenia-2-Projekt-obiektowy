using SchoolRental.Models;
using SchoolRental.Models.Equipment;

namespace SchoolRental.Services;

public class DeviceService
{
    private readonly List<Device> _devices = new();

    public void AddDevice(Device device)
    {
        _devices.Add(device);
    }

    public List<Device> GetAll()
    {
        return _devices;
    }

    public List<Device> GetAvailable()
    {
        return _devices.Where(d => d.Status == DeviceStatus.Available).ToList();
    }
    
}