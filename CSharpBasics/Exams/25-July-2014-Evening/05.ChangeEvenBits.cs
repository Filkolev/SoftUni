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

        ulong numberToChange = ulong.Parse(Console.ReadLine());

        int bitsToChange = getBitsCount(biggestNumber);
        if (numberOfInputs == 0)
        {
            bitsToChange = 0;
        }        

        int bitsChanged = 0;

        for (int j = 0; j < bitsToChange; j++)
        {
            int currentBit = (int)((numberToChange >> j * 2) & 1);            

            if (currentBit == 0)
            {
                bitsChanged++;
                ulong one = 1u;
                ulong mask = one << j * 2;
                numberToChange = numberToChange | mask;
            }
        }

        Console.WriteLine(numberToChange);
        Console.WriteLine(bitsChanged);
    }

    public static int getBitsCount(int number)
    {
        int count = 0;       

        while (number > 0)
        {
            count++;
            number = number >> 1;
        }

        return Math.Max(1, count);
    }
}
