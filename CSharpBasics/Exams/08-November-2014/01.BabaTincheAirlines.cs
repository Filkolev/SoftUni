using System;

class BabaTincheAirlines
{
    static void Main()
    {
        string[] firstClassInput = Console.ReadLine().Split();
        int firstClassPassengers = int.Parse(firstClassInput[0]);
        int firstClassFrequent = int.Parse(firstClassInput[1]);
        int firstClassMeals = int.Parse(firstClassInput[2]);

        string[] businessInput = Console.ReadLine().Split();
        int businessPassengers = int.Parse(businessInput[0]);
        int businessFrequent = int.Parse(businessInput[1]);
        int businessMeals = int.Parse(businessInput[2]);

        string[] economyInput = Console.ReadLine().Split();
        int economyPassengers = int.Parse(economyInput[0]);
        int economyFrequent = int.Parse(economyInput[1]);
        int economyMeals = int.Parse(economyInput[2]);

        const int TOTAL_INCOME = 233160;

        decimal income = 0;

        income += (firstClassPassengers - firstClassFrequent) * 7000;
        income += (firstClassFrequent * 7000 * 0.3m);
        income += (firstClassMeals * 7000 * 0.005m);

        income += (businessPassengers - businessFrequent) * 3500;
        income += (businessFrequent * 3500 * 0.3m);
        income += (businessMeals * 3500 * 0.005m);

        income += (economyPassengers - economyFrequent) * 1000;
        income += (economyFrequent * 1000 * 0.3m);
        income += (economyMeals * 1000 * 0.005m);

        Console.WriteLine((int)income);
        Console.WriteLine(TOTAL_INCOME - (int)income);
    }
}
