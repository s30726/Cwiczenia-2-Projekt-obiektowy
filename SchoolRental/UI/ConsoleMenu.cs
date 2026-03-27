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

    public void Demo()
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
    
    public void InteractiveConsole()
    {
        while (true)
        {
            PrintMenu();
            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1": AddUser(); break;
                    case "2": AddDevice(); break;
                    case "3": ShowAllDevices(); break;
                    case "4": ShowAvailableDevices(); break;
                    case "5": RentDevice(); break;
                    case "6": ReturnDevice(); break;
                    case "7": MarkUnavailable(); break;
                    case "8": ShowUserRentals(); break;
                    case "9": ShowOverdue(); break;
                    case "10": ShowReport(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid option"); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private void PrintMenu()
    {
        Console.WriteLine("""
        ===== MENU =====
        1. Add user
        2. Add device
        3. Show all devices
        4. Show available devices
        5. Rent device
        6. Return device
        7. Mark device as unavailable
        8. Show user's active rentals
        9. Show overdue rentals
        10. Show report
        0. Exit
        =================
        """);
    }

    private void AddUser()
    {
        Console.WriteLine("1. Student  2. Employee");
        var type = Console.ReadLine();

        Console.Write("First name: ");
        var firstName = Console.ReadLine();

        Console.Write("Last name: ");
        var lastName = Console.ReadLine();

        if (type == "1")
        {
            Console.Write("Student number: ");
            var number = Console.ReadLine();
            _userService.AddUser(new Student(firstName, lastName, number));
        }
        else if (type == "2")
        {
            Console.Write("Employee number: ");
            var number = Console.ReadLine();
            _userService.AddUser(new Employee(firstName, lastName, number));
        }
        else
        {
            Console.WriteLine("Invalid option");
            return;
        }
        
        Console.WriteLine("User added: ");
        Console.WriteLine(_userService.GetAll().Last());
    }

    private void AddDevice()
    {
        Console.WriteLine("1. Laptop  2. Projector  3. Camera");
        var type = Console.ReadLine();

        Console.Write("Name: ");
        var name = Console.ReadLine();

        switch (type)
        {
            case "1":
                Console.Write("RAM: ");
                int ram = int.Parse(Console.ReadLine());
                Console.Write("CPU: ");
                var cpu = Console.ReadLine();
                _deviceService.AddDevice(new Laptop(name, ram, cpu));
                break;

            case "2":
                Console.Write("Lumens: ");
                int lumens = int.Parse(Console.ReadLine());
                Console.Write("Resolution: ");
                var res = Console.ReadLine();
                _deviceService.AddDevice(new Projector(name, lumens, res));
                break;

            case "3":
                Console.Write("Megapixels: ");
                int mp = int.Parse(Console.ReadLine());
                Console.Write("Sensor: ");
                var sensor = Console.ReadLine();
                _deviceService.AddDevice(new Camera(name, mp, sensor));
                break;
        }
        Console.WriteLine("Device added: ");
        Console.WriteLine(_deviceService.GetAll().Last());
    }

    private void ShowAllDevices()
    {
        _deviceService.GetAll().ForEach(d => Console.WriteLine(d));
    }

    private void ShowAvailableDevices()
    {
        Console.WriteLine("Available devices: ");
        _deviceService.GetAvailable().ForEach(d => Console.WriteLine(d));
    }

    private void RentDevice()
    {
        var user = SelectUser();
        var device = SelectDevice();

        Console.Write("Days: ");
        int days = int.Parse(Console.ReadLine());

        var rental = _rentalService.RentDevice(user, device, days);
        Console.WriteLine("Rental created:");
        Console.WriteLine(rental);
    }

    private void ReturnDevice()
    {
        var rental = SelectRental();
        _rentalService.ReturnDevice(rental);
        Console.WriteLine("Returned:");
        Console.WriteLine(rental);
    }

    private void MarkUnavailable()
    {
        var device = SelectDevice();
        device.MarkAsUnavailable();
    }

    private void ShowUserRentals()
    {
        var user = SelectUser();
        var rentals = _rentalService.GetActiveRentals(user);
        rentals.ForEach(r => Console.WriteLine(r));
    }

    private void ShowOverdue()
    {
        _rentalService.GetOverdueRentals()
            .ForEach(r => Console.WriteLine(r));
    }

    private void ShowReport()
    {
        var report = _reportService.GenerateReport(
            _deviceService.GetAll(),
            _rentalService.GetAllRentals()
        );

        Console.WriteLine(report);
    }
    

    private User SelectUser()
    {
        var users = _userService.GetAll();

        Console.WriteLine("Select user:");
        for (int i = 1; i < users.Count + 1; i++)
            Console.WriteLine($"{i}: {users[i - 1]}");

        int index = int.Parse(Console.ReadLine());
        return users[index - 1];
    }

    private Device SelectDevice()
    {
        var devices = _deviceService.GetAll();
        
        Console.WriteLine("Select device:");
        for (int i = 1; i < devices.Count + 1; i++)
            Console.WriteLine($"{i}: {devices[i - 1]}");

        int index = int.Parse(Console.ReadLine());
        return devices[index - 1];
    }

    private Rental SelectRental()
    {
        var rentals = _rentalService.GetAllRentals();

        Console.WriteLine("Select rental:");
        for (int i = 1; i < rentals.Count + 1; i++)
            Console.WriteLine($"{i}: {rentals[i - 1]}");

        int index = int.Parse(Console.ReadLine());
        return rentals[index - 1];
    }
}