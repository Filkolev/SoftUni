using System;

// Write an expression that checks if given integer is odd or even. 

class OddOrEvenIntegers
{
    static void Main()
    {
        Console.Write("Enter an integer to check if it's odd: ");
        int integer = int.Parse(Console.ReadLine());
        
        Console.WriteLine(integer % 2 != 0 ? "\nThe number is odd.\n" : "\nThe number is even.\n");     
    }
}
