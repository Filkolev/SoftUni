using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/14

class WeAllLoveBits
{
    static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfInputs; i++)
        {
            uint currentNumber = uint.Parse(Console.ReadLine());

            uint result = 0;

            while (currentNumber > 0)
            {
                result <<= 1;
                uint bit = currentNumber & 1;
                currentNumber >>= 1;
                result |= bit;
                
            }

            Console.WriteLine(result);
        }
    }
}
