using System;

// Write a program that reads 3 real numbers from the console and prints their sum.

class SumOf3Numbers
{
    static void Main()
    {
        Console.Write("Please enter the first number: ");
        double firstNumber = double.Parse(Console.ReadLine());

        Console.Write("Please enter the second number: ");
        double secondNumber = double.Parse(Console.ReadLine());

        Console.Write("Please enter the third number: ");
        double thirdNumber = double.Parse(Console.ReadLine());

        double sum = firstNumber + secondNumber + thirdNumber;

        Console.WriteLine("\nThe sum of the three numbers is {0}.", sum);
    }
}
