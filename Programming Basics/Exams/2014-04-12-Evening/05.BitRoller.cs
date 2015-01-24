using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/71

class BitRoller
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine()); 
        int fixedBitPosition = int.Parse(Console.ReadLine()); 
        int rolls = int.Parse(Console.ReadLine()); 

        int result;

        int fixedBit = (number >> fixedBitPosition) & 1; 
        int leftSide = (number >> (fixedBitPosition + 1)); 
        int rightMask = (1 << fixedBitPosition) - 1;
        int rightSide = rightMask & number; 

        int temp = (leftSide << fixedBitPosition) | rightSide; // The result of taking the fixed bit out of n

        // Roll the bits
        for (int i = 0; i < rolls; i++)
        {
            int lastBit = temp & 1;
            temp = temp >> 1;
            lastBit = lastBit << 17;
            temp = temp | lastBit;
        }

        int tempLeft = temp >> fixedBitPosition;

        int tempRight = rightMask & temp;

        // Re-insert the fixed bit after the rest of the bits have been rolled
        result = tempRight | (fixedBit << fixedBitPosition) | (tempLeft << fixedBitPosition + 1);

        Console.WriteLine(result);
    }
}
