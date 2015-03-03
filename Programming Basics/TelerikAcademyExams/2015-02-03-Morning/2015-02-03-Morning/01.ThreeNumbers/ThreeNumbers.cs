namespace _01.ThreeNumbers
{
    using System;
    using System.Linq;

    public class ThreeNumbers
    {
        public static void Main()
        {
            int[] numbers = new int[3];

            for (int i = 0; i < 3; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(numbers.Max());
            Console.WriteLine(numbers.Min());
            Console.WriteLine("{0:F2}", numbers.Average());
        }
    }
}
