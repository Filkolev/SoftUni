using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/34

class SumOfElements
{
    static void Main()
    {
        string input = Console.ReadLine();

        string[] strings = input.Split();


        int[] numbers = new int[strings.Length];
        long sumOfElements = 0;
        long minimumDiff = Int64.MaxValue;

        for (int i = 0; i < strings.Length; i++)
        {
            numbers[i] = Convert.ToInt32(strings[i]);
            sumOfElements += numbers[i];
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            if (2L * numbers[i] == sumOfElements)
            {
                Console.WriteLine("Yes, sum={0}", numbers[i]);
                return;
            }

            else if (Math.Abs(sumOfElements - 2L * numbers[i]) < minimumDiff)
            {
                minimumDiff = (long)Math.Abs(sumOfElements - 2L * numbers[i]);
            }
        }

        Console.WriteLine("No, diff={0}", minimumDiff);

    }
}
