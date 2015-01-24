using System;

/* Using loops write a program that converts a hexadecimal integer number to its decimal form. 
 The input is entered as string. The output should be a variable of type long. Do not use 
 the built-in .NET functionality. */

class HexadecimalToDecimalNumber
{
    static void Main()
    {
        Console.Write("Enter a number in hexadecimal format: ");
        string hexNumber = Console.ReadLine();
        long decNumber = 0;

        for (int i = 0; i < hexNumber.Length; i++)
			{
                char currentSymbol = hexNumber[hexNumber.Length - i - 1];

                switch (currentSymbol)
                {
                    case '1':
                        decNumber += (long)(1 * (Math.Pow(16.0, i)));
                        break;
                    case '2':
                        decNumber += (long)(2 * (Math.Pow(16.0, i)));
                        break;
                    case '3':
                        decNumber += (long)(3 * (Math.Pow(16.0, i)));
                        break;
                    case '4':
                        decNumber += (long)(4 * (Math.Pow(16.0, i)));
                        break;
                    case '5':
                        decNumber += (long)(5 * (Math.Pow(16.0, i)));
                        break;
                    case '6':
                        decNumber += (long)(6 * (Math.Pow(16.0, i)));
                        break;
                    case '7':
                        decNumber += (long)(7 * (Math.Pow(16.0, i)));
                        break;
                    case '8':
                        decNumber += (long)(8 * (Math.Pow(16.0, i)));
                        break;
                    case '9':
                        decNumber += (long)(9 * (Math.Pow(16.0, i)));
                        break;
                    case 'A':
                    case 'a':
                        decNumber += (long)(10 * (Math.Pow(16.0, i)));
                        break;
                    case 'B':
                    case 'b':
                        decNumber += (long)(11 * (Math.Pow(16.0, i)));
                        break;
                    case 'C':
                    case 'c':
                        decNumber += (long)(12 * (Math.Pow(16.0, i)));
                        break;
                    case 'D':
                    case 'd':
                        decNumber += (long)(13 * (Math.Pow(16.0, i)));
                        break;
                    case 'E':
                    case 'e':
                        decNumber += (long)(14 * (Math.Pow(16.0, i)));
                        break;
                    case 'F':
                    case 'f':
                        decNumber += (long)(15 * (Math.Pow(16.0, i)));
                        break;
                    default: Console.WriteLine("Invalid input!");
                        break;
                }  
			}

        Console.WriteLine("\nThe decimal representation of \"{0}\" is: {1}.\n", hexNumber, decNumber);        
    }
}
