using SchoolRental.Models;
using SchoolRental.Models.Equipment;
using SchoolRental.Models.Users;

namespace SchoolRental;

class Program
{
    static void Main(string[] args)
    {
        Device myLaptop = new Laptop("Asus", 8, "i7");
        Console.Write(myLaptop);
        User myself = new Student("Karol", "Kubica", "s30726");
        Console.Write(myself);
        Rental myFirstRent = new Rental(myself, myLaptop, 5);
        Console.Write(myFirstRent);
    }
}