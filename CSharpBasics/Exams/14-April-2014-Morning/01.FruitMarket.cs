using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/74

class FruitMarket
{
    static void Main()
    {
        string dayOfWeek = Console.ReadLine();

        decimal quantity1 = decimal.Parse(Console.ReadLine());
        string product1 = Console.ReadLine();

        decimal quantity2 = decimal.Parse(Console.ReadLine());
        string product2 = Console.ReadLine();

        decimal quantity3 = decimal.Parse(Console.ReadLine());
        string product3 = Console.ReadLine();

        decimal totalPrice = 0;

        totalPrice += quantity1 * PriceOfProduct(product1, dayOfWeek);
        totalPrice += quantity2 * PriceOfProduct(product2, dayOfWeek);
        totalPrice += quantity3 * PriceOfProduct(product3, dayOfWeek);

        Console.WriteLine("{0:F2}", totalPrice);
    }

    public static decimal PriceOfProduct(string product, string day)
    {
        decimal price = 0;
        
        switch (product)
        {
            case "banana": price = 1.80m; 
                break;
            case "cucumber": price = 2.75m;
                break;
            case "tomato": price = 3.20m;
                break;
            case "orange": price = 1.60m;
                break;
            case "apple": price = 0.86m;
                break;
        }

        if (day == "Friday")
        {
            price *= 0.9m;

        }

        if (day == "Sunday")
        {
            price *= 0.95m;
        }

        if (day == "Tuesday" && (product == "banana" || product == "orange" || product == "apple"))
        {
            price *= 0.8m;
        }

        if (day == "Wednesday" && (product == "cucumber" || product == "tomato"))
        {
            price *= 0.9m;
        }

        if (day == "Thursday" && product == "banana")
        {
            price *= 0.7m;
        }

        return price;
    }
}
