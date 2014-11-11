using System;

class Budget
{
    static void Main()
    {
        int money = int.Parse(Console.ReadLine());
        int weekdaysOut = int.Parse(Console.ReadLine());
        int hometownWeekends = int.Parse(Console.ReadLine());

        const int TOTAL_DAYS = 30;
        const int WEEKEND_DAYS = 8;

        int normalWeekends = WEEKEND_DAYS - 2 * hometownWeekends;
        int normalWeekdays = TOTAL_DAYS - WEEKEND_DAYS;

        int expenses = (int)(money * 0.03) * weekdaysOut;
        expenses += normalWeekdays * 10;
        expenses += normalWeekends * 20;
        expenses += 150;

        int balance = money - expenses;

        if (balance == 0)
        {
            Console.WriteLine("Exact Budget.");
        }
        else if (balance > 0)
        {
            Console.WriteLine("Yes, leftover {0}.", balance);
        }
        else
        {
            Console.WriteLine("No, not enough {0}.", -balance);
        }
    }
}
