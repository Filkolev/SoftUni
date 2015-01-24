using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/270

class TripleRotationOfDigits
{
    static void Main()
    {
        string input = Console.ReadLine();

        int numberOfDigits = input.Length;

        int number = int.Parse(input);

        for (int i = 0; i < 3; i++)
        {
            int digit = number % 10;
            if (digit == 0)
            {
                numberOfDigits--;
            }

            number /= 10;
            number += digit * (int)Math.Pow(10, numberOfDigits - 1);
        }

        Console.WriteLine(number);
    }
}
