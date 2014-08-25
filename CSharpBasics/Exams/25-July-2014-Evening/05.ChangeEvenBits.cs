using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/183

class ChangeEvenBits
{
    static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());

        int biggestNumber = Int32.MinValue;

        for (int i = 0; i < numberOfInputs; i++)
        {
            int number = int.Parse(Console.ReadLine());
            biggestNumber = Math.Max(number, biggestNumber);
        }

        int numberToChange = int.Parse(Console.ReadLine());

        int bitsToChange = getBitsCount(biggestNumber);

        int bitsChanged = 0;

        for (int j = 0; j < bitsToChange; j++)
        {
            int currentBit = (numberToChange >> j * 2) & 1;            

            if (currentBit == 0)
            {
                bitsChanged++;
                int mask = 1 << j * 2;
                numberToChange = numberToChange | mask;
            }
        }

        Console.WriteLine(numberToChange);
        Console.WriteLine(bitsChanged);
    }

    public static int getBitsCount(int number)
    {
        int count = 0;

        if (number == 0)
        {
            return 1;
        }

        while (number > 0)
        {
            count++;
            number = number >> 1;
        }

        return count;
    }
}
