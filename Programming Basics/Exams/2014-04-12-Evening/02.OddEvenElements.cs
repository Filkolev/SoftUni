using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/65

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        if (input == "")
        {
            Console.WriteLine("OddSum=No, OddMin=No, OddMax=No, EvenSum=No, EvenMin=No, EvenMax=No");
            return;
        }

        decimal[] numbers = Array.ConvertAll(input.Split(), x => decimal.Parse(x));

        decimal oddMin = decimal.MaxValue;
        decimal oddMax = decimal.MinValue;
        decimal oddSum = 0;

        decimal evenMin = decimal.MaxValue;
        decimal evenMax = decimal.MinValue;
        decimal evenSum = 0;

        decimal oddCount = 0;
        decimal evenCount = 0;

        for (int i = 1; i <= numbers.Length; i++)
        {
            if (i % 2 == 0)
            {
                evenMin = Math.Min(evenMin, numbers[i - 1]);
                evenMax = Math.Max(evenMax, numbers[i - 1]);
                evenSum += numbers[i - 1];
                evenCount++;
            }

            else
            {
                oddMin = Math.Min(oddMin, numbers[i - 1]);
                oddMax = Math.Max(oddMax, numbers[i - 1]);
                oddSum += numbers[i - 1];
                oddCount++;
            }
        }

        if (numbers.Length == 1)
        {
            Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum=No, EvenMin=No, EvenMax=No",
                (double)oddSum, (double)oddMin, (double)oddMax);           
        }

        else
        {
            Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}",
                (double)oddSum, (double)oddMin, (double)oddMax, (double)evenSum, (double)evenMin, (double)evenMax);
        }

    }
}
