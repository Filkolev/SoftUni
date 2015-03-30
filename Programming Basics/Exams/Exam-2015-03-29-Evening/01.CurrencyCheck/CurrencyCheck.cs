namespace _01.CurrencyCheck
{
    using System;
    using System.Linq;

    public class CurrencyCheck
    {
        public static void Main()
        {
            const decimal RubleRate = 3.5m / 100;
            const decimal DollarRate = 1.5m;
            const decimal EuroRate = 1.95m;

            decimal[] prices =
            {
                decimal.Parse(Console.ReadLine()) * RubleRate,
                decimal.Parse(Console.ReadLine()) * DollarRate,
                decimal.Parse(Console.ReadLine()) * EuroRate,
                decimal.Parse(Console.ReadLine()) / 2,
                decimal.Parse(Console.ReadLine())
            };

            decimal bestPrice = prices.Min();

            Console.WriteLine("{0:f2}", bestPrice);
        }
    }
}
