using System;

/* Using bitwise operators, write an expression for finding the value of the bit #3 
 of a given unsigned integer. The bits are counted from right to left, starting from 
 bit #0. The result of the expression should be either 1 or 0. */

class ExtractBit3
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        uint n = uint.Parse(Console.ReadLine());
        uint nRight3 = n >> 3;
        uint bit = nRight3 & 1;
        Console.WriteLine("\nBit #3 of {0} is {1}.\n", n, bit);

    }
}
