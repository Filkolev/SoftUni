using System;

/* We are given an integer number n, a bit value v (v=0 or 1) and a position p. Write a sequence 
 of operators (a few lines of C# code) that modifies n to hold the value v at the position p 
 from the binary representation of n while preserving all other bits in n. */

class ModifyBitAtGivenPosition
{
    static void Main()
    {        
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine()); 
        Console.Write("Enter the position of the bit you wish to modify: ");
        int bitPosition = int.Parse(Console.ReadLine()); 
        Console.Write("What value do you wish to set for the bit at position {0}? ", bitPosition);
        int valueToSet = int.Parse(Console.ReadLine());

        if (valueToSet == 0)
        {
            int mask = ~(1 << bitPosition);
            int result = number & mask;
            Console.WriteLine(
                "\nThe result of changing bit {0} of the number {1} to {2} is {3}.\n", 
                bitPosition, number, valueToSet, result);
        }
        else
        {
            int mask = 1 << bitPosition;
            int result = number | mask;
            Console.WriteLine(
                "\nThe result of changing bit {0} of the number {1} to {2} is {3}.\n", 
                bitPosition, number, valueToSet, result);
        }        
    }
}
