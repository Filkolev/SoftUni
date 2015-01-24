using System;
using System.Text;

/* Using loops write a program that converts an integer number to its binary representation. 
 The input is entered as long. The output should be a variable of type string. Do not use 
 the built-in .NET functionality. */

class DecimalToBinaryNumber
{
    static void Main()
    {
        string resultingString = "";

        Console.Write("Enter an integer: ");
        long inputInteger = long.Parse(Console.ReadLine());
        long initialInput = inputInteger;        

        StringBuilder result = new StringBuilder();

        while (inputInteger > 0)
        {
            result.Insert(0, (inputInteger % 2));           
            inputInteger >>= 1;
        }

        resultingString = result.ToString();

        if (inputInteger == 0)
        {
            resultingString = "0";
        }

        Console.WriteLine("\nThe binary representation of {0} is: {1}\n", initialInput, resultingString);
    }
}
