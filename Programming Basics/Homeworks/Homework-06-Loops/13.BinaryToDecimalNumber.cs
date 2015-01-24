using System;

/* Using loops write a program that converts a binary integer number to its decimal form. 
 The input is entered as string. The output should be a variable of type long. Do not 
 use the built-in .NET functionality. */

class BinaryToDecimalNumber
{
    static void Main()
    {
        Console.Write("Enter the number in binary: ");
        string binaryNumber = Console.ReadLine();
        double decimalNumber = 0;

        for (int i = 0; i < binaryNumber.Length; i++)
        {
            int currentBitPosition = (binaryNumber.Length - 1) - i;
            
            if (binaryNumber[currentBitPosition] == '1')
            {
                decimalNumber += Math.Pow(2, i);
            }            
        }

        Console.WriteLine("\nThe decimal representation of the number is: {0}.\n", decimalNumber);
    }
}
