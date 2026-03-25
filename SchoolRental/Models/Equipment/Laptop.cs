namespace SchoolRental.Models.Equipment;

public class Laptop : Device
{
    public int RamGb { get; set; }
    public string Cpu { get; set; }

    public Laptop(string name, int ramgb, string cpu) : base(name)
    {
        RamGb = ramgb;
        Cpu = cpu;
    }
    
    public override string ToString()
    {
        return base.ToString() + $" | RAM: {RamGb} | CPU: {Cpu}\n";
    }
}