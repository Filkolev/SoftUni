using System;
using System.Numerics;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/450

class Secrets
{
    static void Main()
    {
        BigInteger number = BigInteger.Parse(Console.ReadLine());

        if (number < 0)
        {
            number *= (-1);
        }

        BigInteger savedInputNum = number;

        BigInteger specialSum = 0;
        int position = 1;

        while (number > 0)
        {
            int digit = (int)(number % 10);

            if (position % 2 == 0)
            {
                specialSum += digit * digit * position;
            }

            else
            {
                specialSum += digit * position * position;
            }

            position++;
            number /= 10;
        }

        Console.WriteLine(specialSum);

        int numberOfLetters = (int)(specialSum % 10);
        int startLetter = (int)(specialSum % 26) + 'A';

        if (numberOfLetters == 0)
        {
            Console.WriteLine("{0} has no secret alpha-sequence", savedInputNum);
        }

        else
        {
            for (int i = 0; i < numberOfLetters; i++)
            {
                Console.Write((char)startLetter);
                startLetter++;

                if (startLetter > 'Z')
                {
                    startLetter = 'A';
                }
            }
        }
    }
}
