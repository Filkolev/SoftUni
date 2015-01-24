using System;

// Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a 
// given 32-bit unsigned integer. The first and the second sequence of bits may not overlap.

class AdvancedBitExchange
{
    static void Main()
    {
        Console.Write("Enter a positive integer.\nn = ");
        uint number = 0;
        bool parsed = uint.TryParse(Console.ReadLine(), out number);

        // If the number cannot be parsed into uint, it's out of range
        if (!parsed)
        {
            Console.WriteLine("\nThe number is out of range!\n");
            return; // Stop executing the program in this case
        }

        Console.Write("\nStarting position of the first bit sequence = ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("Starting position of the second bit sequence = ");
        int q = int.Parse(Console.ReadLine());
        Console.Write("Number of bits to exchange = ");
        int length = int.Parse(Console.ReadLine());

        // I check which sequence is to the left and which is to the right
        int right = Math.Min(p, q);
        int left = Math.Max(p, q);

        if (right + length > left)
        {
            Console.WriteLine("\nThe sequences are overlapping!\n");
            return;
        }

        if (left + length > 32)
        {
            Console.WriteLine("\nThe number is out of range!\n");
            return;
        }        

        uint mask = 0u;

        for (int i = 0; i < length; i++)
        {            
            mask = mask << 1;
            mask = mask | 1;
        }

        uint rightBits = (number >> right) & mask;
        uint leftBits = (number >> left) & mask;

        number = number & ~(mask << right);
        number = number | (leftBits << right);

        number = number & ~(mask << left);
        number = number | (rightBits << left);

        Console.WriteLine("\nThe result after the exchange is {0}.\n", number);
    }
}
