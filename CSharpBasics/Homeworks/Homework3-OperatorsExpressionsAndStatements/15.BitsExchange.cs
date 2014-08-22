// To be optimized

using System;

// Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

class BitsExchange
{
    static void Main()
    {
        Console.Write("n = ");
        uint n = uint.Parse(Console.ReadLine());

        // I declare an array where I'll store all 6 bits I'm about to exchange
        uint[] bits = new uint[6];

        // This loop extracts the first 3 bits
        for (int i = 0; i < 3; i++)
        {
            bits[i] = (n >> (3+i)) & 1;
        }

        // Extract the other 3 bits
        for (int i = 0; i < 3; i++)
        {
            bits[i+3] = (n >> 24 +i) & 1;
        }

        // Start exchanging the bits
        for (int i = 0; i < bits.Length; i++)
        {
            // The first 3 bits go to the left
            if (i<bits.Length/2)
            {
                if (bits[i] == 0)
                {
                    uint mask = ~(1u << i + 24);
                    n = n & mask;
                }

                else
                {
                    uint mask = 1u << i + 24;
                    n = n | mask;
                }
            }

            // The other 3 bits are moved to the right
            else
            {
                if (bits[i] == 0)
                {
                    uint mask = ~(1u << i);
                    n = n & mask;
                }

                else
                {
                    uint mask = 1u << i;
                    n = n | mask;
                }
            }
        }
        
    
    Console.WriteLine("\nWhen we exchange bits 3, 4 and 5 with bits 24, 25 and 26 in the number n we get {0}.\n", n);
    }
}
