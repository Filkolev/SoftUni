using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/505

class AngryFemaleGPS
{
    static void Main()
    {
        string input = Console.ReadLine().Replace("-", "");
        int oddSum = 0;
        int evenSum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            int number = input[i] - '0';

            if (number % 2 == 0)
            {
                evenSum += number;
            }

            else
            {
                oddSum += number;
            }
        }

        if (oddSum > evenSum)
        {
            Console.WriteLine("left {0}", oddSum);
        }

        else if (oddSum == evenSum)
        {
            Console.WriteLine("straight {0}", oddSum);
        }

        else
        {
            Console.WriteLine("right {0}", evenSum);
        }
    }
}
