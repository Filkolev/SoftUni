// To be optimized

using System;

// Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a 
// given 32-bit unsigned integer. The first and the second sequence of bits may not overlap.

class AdvancedBitExchange
{
    static void Main()
    {
        Console.Write("n = ");
        uint n = 0;
        bool parsed = uint.TryParse(Console.ReadLine(), out n);

        // If the number cannot be parsed into uint, it's out of range
        if (!parsed)
        {
            Console.WriteLine("\nout of range\n");
            return; // Stop executing the program in this case
        }

        Console.Write("p = ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("q = ");
        int q = int.Parse(Console.ReadLine());
        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine()); // length

        // I check which sequence is to the left and which is to the right
        int right = Math.Min(p, q);
        int left = Math.Max(p, q);

        // Array to store all the bits I'll exchange
        uint[] bits = new uint[2*k];

        // If the lenght k is large enough, the two sequences will overlap
        if (right+k-1 >= left)
        {
            Console.WriteLine("\noverlapping\n");
            return; // Stop executing the program in this case
        }

        // If the left sequence starts too far to the left it will go out of 
        // range when we go k-1 bits to the left; same if either p or q are negative
        if (left + k - 1 >= 32 || p <0 || k<0)
        {
            Console.WriteLine("\nout of range\n");
            return;
        }

        // This loop extracts the right sequence of bits and puts them in the array
        for (int i = 0; i < k; i++)
        {
            bits[i] = (n >> right + i) & 1;
        }

        // Extract the sequence of bits to the left
        for (int i = 0; i < k; i++)
        {
            bits[k+i] = (n >> left + i) & 1;
        }


        // Exchange the bits using the same algorithm as in Problem 15
        for (int i = 0; i < k; i++)
        {
            if (bits[i]==0)
            {
                n = ~(1u << left +i) & n;
            }
            else
            {
                n = (1u << left + i) | n;
            }
           
        }

        for (int i = 0; i < k; i++)
        {
            if (bits[k+i]==0)
            {
                n = ~(1u << right + i) & n;
            }
            else
            {
                n = (1u << right + i) | n;
            }
        }


        Console.WriteLine("\nThe result after the exchange is {0}.\n", n);

    }
}
