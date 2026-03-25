namespace SchoolRental.Models.Equipment;

public class Projector : Device
{
    public int Lumens { get; set; }
    public string Resolution { get; set; }

    public Projector(string name, int lumens, string resolution) : base(name)
    {
        Lumens = lumens;
        Resolution = resolution;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Lumens: {Lumens} | Resolution: {Resolution}\n";
    }
}