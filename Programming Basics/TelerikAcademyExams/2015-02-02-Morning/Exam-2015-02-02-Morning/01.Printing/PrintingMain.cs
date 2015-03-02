namespace _01.Printing
{
    using System;

    public class PrintingMain
    {
        public static void Main()
        {
            const int SheetsPerRealm = 500;

            int countOfStudents = int.Parse(Console.ReadLine());
            int sheetsPerStudent = int.Parse(Console.ReadLine());
            decimal pricePerRealm = decimal.Parse(Console.ReadLine());

            int totalSheets = countOfStudents * sheetsPerStudent;
            decimal countOfRealms = (decimal)totalSheets / SheetsPerRealm;
            decimal totalPrice = countOfRealms * pricePerRealm;

            Console.WriteLine("{0:F2}", totalPrice);
        }
    }
}
