namespace SchoolRental.Models.Equipment;

public class Device
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public DeviceStatus Status { get; set; }

    protected Device(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Status = DeviceStatus.Available;
    }

    public override string ToString()
    {
        return $"Id: {Id} | Name: {Name}";
    }
    
}