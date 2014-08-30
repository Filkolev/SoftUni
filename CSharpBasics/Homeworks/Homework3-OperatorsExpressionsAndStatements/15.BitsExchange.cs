using System;

// Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

class BitsExchange
{
    static void Main()
    {
        Console.Write("Enter a positive 32-bit integer:\nn = ");
        uint number = uint.Parse(Console.ReadLine());

        uint mask = 7;

        uint rightBits = (number >> 3) & mask;
        uint leftBits = (number >> 24) & mask;

        number = number & ~(mask << 3);
        number = number | (leftBits << 3);

        number = number & ~(mask << 24);
        number = number | (rightBits << 24);        
    
    Console.WriteLine("\nWhen we exchange bits 3, 4 and 5 with bits 24, 25 and 26 in the number n we get {0}.\n", number);
    }
}
