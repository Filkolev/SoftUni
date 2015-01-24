using System;

/* Write a Boolean expression that returns if the bit at position p (counting from 0, starting from the right) 
 in given integer number n has value of 1. */

class CheckBitAtGivenPosition
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        uint n = uint.Parse(Console.ReadLine());
        Console.Write("Enter the position you want to check: ");
        int p = int.Parse(Console.ReadLine());

        uint nRightP = n >> p;
        uint bit = nRightP & 1;

        Console.WriteLine(
            bit == 1 ? "\nThe bit at position {0} of the integer {1} is 1.\n" : "\nThe bit at position {0} of the integer {1} is NOT 1.\n", 
            p, n);
    }
}
