namespace SchoolRental.Models.Equipment;

public class Equipment
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    //public EquipmentStatus Status { get; set; }

    protected Equipment(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        //Status = EquipmentStatus.Available;
    }

    public override string ToString()
    {
        return $"Name: {Name} | Id: {Id}";
    }
    
}