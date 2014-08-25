using System;

// Problem can be fond here: http://judge.softuni.bg/Contests/Practice/DownloadResource/76

class BiggestTriple
{
    static void Main()
    {
        string inputLine = Console.ReadLine();

        string[] numbers = inputLine.Split();

        int maxSum = Int32.MinValue;
        int sum = 0;
        string biggestTriplet = null;

        for (int i = 0; i + 2 < numbers.Length; i += 3)
        {
            sum += int.Parse(numbers[i]);
            sum += int.Parse(numbers[i + 1]);
            sum += int.Parse(numbers[i + 2]);

            if (sum > maxSum)
            {
                maxSum = sum;
                biggestTriplet = "" + numbers[i] + " " + numbers[i + 1] + " " + numbers[i + 2];
            }

            sum = 0;
        }

        if (numbers.Length % 3 == 1)
        {
            sum = int.Parse(numbers[numbers.Length - 1]);

            if (sum > maxSum)
            {
                maxSum = sum;
                biggestTriplet = "" + numbers[numbers.Length - 1];
            }
        }

        else if (numbers.Length % 3 == 2)
        {
            sum = int.Parse(numbers[numbers.Length - 2]) + int.Parse(numbers[numbers.Length - 1]);

            if (sum > maxSum)
            {
                maxSum = sum;
                biggestTriplet = "" + numbers[numbers.Length - 2] + " " + numbers[numbers.Length - 1];
            }
        }

        Console.WriteLine(biggestTriplet);
    }
}
