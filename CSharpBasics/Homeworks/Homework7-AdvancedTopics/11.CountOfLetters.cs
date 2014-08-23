using System;
using System.Collections.Generic;
using System.Linq;

/* Write a program that reads a list of letters and prints for each letter how many times 
 it appears in the list. The letters should be listed in alphabetical order. Use the input 
 and output format from the examples below. */

class CountOfLetters
{
    static void Main()
    {
        Console.WriteLine("Enter a list of lowercase letters on a single line separated by space:");
        char[] input = Array.ConvertAll(Console.ReadLine().Split(), char.Parse);

        Console.WriteLine("\nHere is the count of each letter:");
        for (char letter = 'a'; letter <= 'z'; letter++)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (letter == input[i])
                {
                    count++;
                }
            }

            if (count > 0)
	        {
		         Console.WriteLine("{0} -> {1}", letter, count);
	        }            
        }

        Console.WriteLine();
    }
}
