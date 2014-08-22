using System;

// Write an expression that checks for given integer if its third digit from right-to-left is 7.

class ThirdDigitIs7
{
    static void Main()
    {
        Console.Write("Please enter an integer: ");
        int n = int.Parse(Console.ReadLine());
        n /= 100;
        int digit = n % 10;
        Console.WriteLine(
            digit == 7 ? "\n{0}: The third digit from right to left is 7.\n" : "\n{0}: The third digit from right to left is not 7.\n", 
            digit == 7);
    }
}
