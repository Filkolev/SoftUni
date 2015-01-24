using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/4

class BinaryDigitsCount
{
    static void Main()
    {
        uint digit = uint.Parse(Console.ReadLine());

        int countOfNumbers = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfNumbers; i++)
        {
            int countOfDigits = 0;
            uint currentNum = uint.Parse(Console.ReadLine());

            while (currentNum > 0)
            {
                uint bit = currentNum & 1;
                if (bit == digit)
                {
                    countOfDigits++;
                }

                currentNum >>= 1;
            }

            Console.WriteLine(countOfDigits);
        }
    }
}
