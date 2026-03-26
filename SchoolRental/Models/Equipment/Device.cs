namespace SchoolRental.Models.Equipment;

public class Device
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public DeviceStatus Status { get; private set; }
    public void MarkAsRented() => Status = DeviceStatus.Rented;
    public void MarkAsAvailable() => Status = DeviceStatus.Available;
    public void MarkAsUnavailable() => Status = DeviceStatus.Unavailable;

    protected Device(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        MarkAsAvailable();
    }

    public override string ToString()
    {
        return $"Id: {Id} | Name: {Name}";
    }
    
}