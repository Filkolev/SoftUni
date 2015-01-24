using System;

// Write an expression that extracts from given integer n the value of given bit at index p.

class ExtractBitFromInteger
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        uint n = uint.Parse(Console.ReadLine());
        Console.Write("Enter the position you want to check: ");
        int p = int.Parse(Console.ReadLine());

        uint nRightP = n >> p;
        uint bit = nRightP & 1;

        Console.WriteLine("\nThe bit at position {0} of the integer {1} is {2}.\n", p, n, bit);
    }
}
