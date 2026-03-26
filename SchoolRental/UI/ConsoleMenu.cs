using SchoolRental.Models;
using SchoolRental.Models.Equipment;
using SchoolRental.Models.Users;
using SchoolRental.Services;

namespace SchoolRental.UI;

public class ConsoleMenu
{
    private readonly UserService _userService;
    private readonly DeviceService _deviceService;
    private readonly RentalService _rentalService;
    private readonly ReportService _reportService;

    public ConsoleMenu()
    {
        var penaltyService = new PenaltyService();
        _userService = new UserService();
        _deviceService = new DeviceService();
        _rentalService = new RentalService(penaltyService);
        _reportService = new ReportService();
    }

    public void Run()
    {
        var laptop = new Laptop("Dell XPS", 16, "i7");
        var projector = new Projector("Epson X1", 3000, "FullHD");
        var camera = new Camera("Canon R5", 45, "CMOS");

        _deviceService.AddDevice(laptop);
        _deviceService.AddDevice(projector);
        _deviceService.AddDevice(camera);

        Console.WriteLine("\nDevices added: ");
        _deviceService.GetAll().ForEach(d => Console.WriteLine(d));


        var student = new Student("Karol", "Kubica", "s30726");
        var employee = new Employee("Piotr", "Gago", "e24067");

        _userService.AddUser(student);
        _userService.AddUser(employee);

        Console.WriteLine("\nUsers added: ");
        _userService.GetAll().ForEach(u => Console.WriteLine(u));

        Console.WriteLine("\nRental: ");
        var correctRental = _rentalService.RentDevice(student, laptop, 3);

        Console.WriteLine(correctRental + "\n");
        Console.WriteLine("Incorrect rental: ");
        try
        {
            _rentalService.RentDevice(student, camera, 3);
            _rentalService.RentDevice(student, projector, 3);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nReturn on time: ");
        _rentalService.ReturnDevice(correctRental);
        Console.WriteLine(correctRental);
        
        var rental2 = _rentalService.RentDevice(employee, projector, 1);
        
        typeof(Rental)
            .GetProperty("RentalEndDate")!
            .SetValue(rental2, DateTime.Now.AddDays(-2));

        Console.WriteLine("\nReturn not on time: ");
        _rentalService.ReturnDevice(rental2);
        Console.WriteLine(rental2);


        Console.WriteLine("\nFinal report: ");
        var report = _reportService.GenerateReport(_deviceService.GetAll(), _rentalService.GetAllRentals());

        Console.WriteLine(report);
        
        














}
}