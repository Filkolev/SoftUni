using System;

/* Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
•	Calculates the sum of the digits (in our example 2+0+1+1 = 4).
•	Prints on the console the number in reversed order: dcba (in our example 1102).
•	Puts the last digit in the first position: dabc (in our example 1201).
•	Exchanges the second and the third digits: acbd (in our example 2101).

The number has always exactly 4 digits and cannot start with 0. */

class FourDigitNumber
{
    static void Main()
    {
        Console.Write("Please enter a four-digit number: ");
        string n = Console.ReadLine();   
        
        int firstDigit = n[0] - '0';
        int secondDigit = n[1] - '0';
        int thirdDigit = n[2] - '0';
        int fourthDigit = n[3] - '0';

        int sumOfDigits = firstDigit + secondDigit + thirdDigit + fourthDigit;

        Console.WriteLine("\nThe sum of the number's digits is: {0}", sumOfDigits);

        Console.WriteLine("The reversed number is: {3}{2}{1}{0}", n[0], n[1], n[2], n[3]);
        Console.WriteLine("When we put the last digit in front we get: {3}{0}{1}{2}", n[0], n[1], n[2], n[3]);
        Console.WriteLine("When we exchange the second and third digits we get: {0}{2}{1}{3}\n", n[0], n[1], n[2], n[3]);
    }
}
