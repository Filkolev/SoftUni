using System;
using System.Collections;

// Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order.

class RandomizeNumbersFrom1ToN
{
    static void Main()
    {
        Console.Write("n = ");
        string input = Console.ReadLine();       

        int n;
        while (!int.TryParse(input, out n))
        {
            Console.Write("The number you entered isn't valid, please re-enter.\nn =  ");
            input = Console.ReadLine();
        }
       
        ArrayList numbersToN = new ArrayList();

        if (n >= 1)
        {
            for (int i = 1; i <= n; i++)
            {
                numbersToN.Add(i);
            }
        }

        else
        {
            for (int i = 1; i >= n; i--)
            {
                numbersToN.Add(i);
            }
        }

        int initialCount = numbersToN.Count;

        Random randomInteger = new Random();

        for (int i = 0; i < initialCount; i++)
        {            
            int selectedNumber = randomInteger.Next(0, numbersToN.Count);

            Console.Write("{0, 4}", numbersToN[selectedNumber]);   

            numbersToN.Remove(numbersToN[selectedNumber]); // Remove the element that was just printed
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}
