using System;

// Write a Boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

class DivideBy7And5
{
    static void Main()
    {
        Console.Write("Enter an integer to check if it's divisible by both 5 and 7 without remainder: ");
        int n = int.Parse(Console.ReadLine());

        bool isDivisible = (n % 5 == 0) && (n % 7 == 0);

        Console.WriteLine(
            isDivisible ? "\n{0}: The number is divisible by 5 and 7.\n" : "\n{0}: The number is not divisible by 5 and 7.\n", 
            isDivisible);      
        
        
    }
}
