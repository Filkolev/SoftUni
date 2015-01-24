using System;
using System.Numerics;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/450

class Secrets_CharArray
{
    static void Main()
    {
        string input = Console.ReadLine().Replace("-", "");

        char[] digits = input.ToCharArray();

        Array.Reverse(digits);

        BigInteger specialSum = 0;

        for (int index = 1; index <= digits.Length; index++)
        {
            int digit = digits[index - 1] - '0';

            if (index % 2 == 0)
            {
                specialSum = specialSum + (digit * digit * index);
            }
            else
            {
                specialSum = specialSum + (digit * index * index);
            }
        }

        Console.WriteLine(specialSum);

        BigInteger numberOfLetters = specialSum % 10;

        if (numberOfLetters == 0)
        {
            Console.WriteLine("{0} has no secret alpha-sequence", input);
        }
        else
        {
            BigInteger startLetter = (specialSum % 26) + 'A';

            char letter = (char)startLetter;

            for (int i = 0; i < numberOfLetters; i++)
            {
                Console.Write(letter);

                letter++;
                if (letter > 'Z')
                {
                    letter = 'A';
                }
            }
        }
    }
}
