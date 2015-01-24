using System;
using System.Text;

/* Using loops write a program that converts an integer number to its hexadecimal 
 representation. The input is entered as long. The output should be a variable of 
 type string. Do not use the built-in .NET functionality. */

class DecimalToHexadecimalNumber
{
    static void Main()
    {
        string resultingString = "";

        Console.Write("Enter an integer in decimal format: ");
        long inputInteger = long.Parse(Console.ReadLine());
        long initialInput = inputInteger;       

        StringBuilder result = new StringBuilder();

        while (inputInteger > 0)
        {
            switch (inputInteger % 16)
            {
                case 10:
                    result.Insert(0, "A");                    
                    inputInteger /= 16;
                    break;
                case 11:
                    result.Insert(0, "B");                    
                    inputInteger /= 16;
                    break;
                case 12:
                    result.Insert(0, "C");
                    inputInteger /= 16;
                    break;
                case 13:
                    result.Insert(0, "D");
                    inputInteger /= 16;
                    break;
                case 14:
                    result.Insert(0, "E");
                    inputInteger /= 16;
                    break;
                case 15:
                    result.Insert(0, "F");
                    inputInteger /= 16;
                    break;
                default:
                    result.Insert(0, (inputInteger % 16));                    
                    inputInteger /= 16;
                    break;
            }            
        }

        resultingString = result.ToString();

        if (initialInput == 0)
        {
            resultingString = "0";
        }

        Console.WriteLine("\nThe hexadecimal representation of {0} is: {1}\n", initialInput, resultingString);
    }
}
