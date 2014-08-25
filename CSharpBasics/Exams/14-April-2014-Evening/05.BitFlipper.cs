using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/92

class BitFlipper
{
    static void Main()
    {
        ulong initialNumber = ulong.Parse(Console.ReadLine());

        ulong mask = 7;

        for (int currentPosition = 61; currentPosition >= 0; currentPosition--)
        {
            ulong sequence = (initialNumber >> currentPosition) & mask;

            if (sequence == 7 || sequence == 0)
            {
                initialNumber = initialNumber ^ (mask << currentPosition);
                currentPosition -= 2;
            }       
        }

        Console.WriteLine(initialNumber);        
    }
}
