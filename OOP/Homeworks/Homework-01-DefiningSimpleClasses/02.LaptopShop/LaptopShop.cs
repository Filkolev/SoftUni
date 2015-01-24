using System;

class LaptopShop
{
    static void Main()
    {
        Laptop withBasicInfoOnly = new Laptop("N750JV", 2000.233m);
        Console.WriteLine(withBasicInfoOnly);

        Laptop withFullInfo = new Laptop("ThinkPad T60", 280.00m, "Lenovo", "Intel DualCore", "4 GB", "Intel HD Graphics 4600", "80GB WD 5400 rpm", new Battery("Li-Ion", 1.5));
        Console.WriteLine(withFullInfo);


        /*----- INVALID LINES OF CODE -----*/

        // Laptop withEmptyModel = new Laptop("", 500);
        // Laptop withNegativePrice = new Laptop("HP", -2.0m);       
        // Laptop withNegativeBatteryLife = new Laptop("a", 100, "a", new Battery("a", -1));        
    }
}
