namespace SchoolRental.Models.Equipment;

public class Camera : Device
{
    public int Megapixels { get; set; }
    public string SensorType { get; set; }

    public Camera(string name, int megapixels, string sensorType) : base(name)
    {
        Megapixels = megapixels;
        SensorType = sensorType;
    }

    public override string ToString()
    {
        return base.ToString() + $" | MPS: {Megapixels} | SENS: {SensorType}\n";
    }
}