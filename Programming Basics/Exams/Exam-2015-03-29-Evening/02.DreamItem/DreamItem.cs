namespace _02.DreamItem
{
    using System;

    public class DreamItem
    {
        public static void Main()
        {
            const int HolidaysInMonth = 10;

            string input = Console.ReadLine();
            string[] inputData = input.Split('\\');

            string month = inputData[0];
            double moneyPerHour = double.Parse(inputData[1]);
            int hoursPerDay = int.Parse(inputData[2]);
            double itemPrice = double.Parse(inputData[3]);

            int daysInMonth;

            switch (month)
            {
                case "Apr":
                case "June":
                case "Sept":
                case "Nov":
                    daysInMonth = 30;
                    break;
                case "Feb":
                    daysInMonth = 28;
                    break;
                default:
                    daysInMonth = 31;
                    break;
            }

            daysInMonth -= HolidaysInMonth;

            double salary = daysInMonth * moneyPerHour * hoursPerDay;

            if (salary > 700)
            {
                salary *= 1.1;
            }

            double balance = salary - itemPrice;

            if (balance >= 0)
            {
                Console.WriteLine("Money left = {0:f2} leva.", balance);
            }
            else
            {
                Console.WriteLine("Not enough money. {0:f2} leva needed.", -balance);
            }
        }
    }
}
