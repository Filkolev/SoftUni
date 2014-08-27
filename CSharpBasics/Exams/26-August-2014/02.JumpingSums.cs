using System;
using System.Linq;

class JumpingSums
{
    static void Main()
    {
        string input = Console.ReadLine();
        int numberOfJumps = int.Parse(Console.ReadLine());

        int[] numbers = Array.ConvertAll(input.Split(), x => int.Parse(x));

        int[] sums = new int[numbers.Length];

        for (int indexOfNum = 0; indexOfNum < numbers.Length; indexOfNum++)
        {
            int currentIndex = indexOfNum;
            int value = numbers[currentIndex];            

            for (int jumpNumber = 0; jumpNumber < numberOfJumps; jumpNumber++)
            {
                sums[indexOfNum] += value;
                currentIndex = (currentIndex + value) % numbers.Length;
                value = numbers[currentIndex];
            }

            sums[indexOfNum] += value;
        }

        Console.WriteLine("max sum = {0}", sums.Max());
    }
}
