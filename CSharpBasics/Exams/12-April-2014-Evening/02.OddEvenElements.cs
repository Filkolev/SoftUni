using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/65

class OddEvenElements
{
    static void Main()
    {
        string input = Console.ReadLine();

        if (input == "") // In case no input is provided
        {
            Console.WriteLine("OddSum=No, OddMin=No, OddMax=No, EvenSum=No, EvenMin=No, EvenMax=No");
            return;
        }

        string[] numbers = input.Split();

        int numberOfOdd = numbers.Length / 2;
        int numberOfEven = numbers.Length / 2;

        if (numbers.Length % 2 != 0)
        {
            numberOfOdd++;  
        }

        // Using double gets a mistake in one of the tests
        decimal oddMin = decimal.MaxValue;
        decimal oddMax = decimal.MinValue;
        decimal oddSum = 0;

        decimal evenMin = decimal.MaxValue;
        decimal evenMax = decimal.MinValue;
        decimal evenSum = 0;

        for (int i = 0; i < numberOfOdd; i++)
        {
            decimal current = decimal.Parse(numbers[2 * i]);
            oddSum += current;
            oddMin = Math.Min(oddMin, current);
            oddMax = Math.Max(oddMax, current);
        }

        for (int i = 0; i < numberOfEven; i++)
        {
            decimal current = decimal.Parse(numbers[2 * i + 1]);
            evenSum += current;
            evenMin = Math.Min(evenMin, current);
            evenMax = Math.Max(evenMax, current);
        }

        Console.WriteLine("OddSum={0}, OddMin={1}, OddMax={2}, EvenSum={3}, EvenMin={4}, EvenMax={5}", 
            (double)oddSum, // switching to decimal led to more mistakes; converting the end result to double solved the issue
            (double)oddMin,
            (double)oddMax,
            numberOfEven == 0 ? "No" : ((double)evenSum).ToString(),
            numberOfEven == 0 ? "No" : ((double)evenMin).ToString(),
            numberOfEven == 0 ? "No" : ((double)evenMax).ToString());       
    }
}
