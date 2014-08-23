using System;
using System.Linq;
using System.Collections.Generic;

/* Write a program that takes as input two lists of integers and joins them. The result should 
 hold all numbers from the first list, and all numbers from the second list, without repeating 
 numbers, and arranged in increasing order. The input and output lists are given as integers, 
 separated by a space, each list at a separate line. */


class JoinLists
{
    static void Main()
    {
        Console.WriteLine("Enter the first line of integers:");
        int[] firstLine = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        Console.WriteLine("\nEnter the second line of integers:");
        int[] secondLine = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        IEnumerable<int> union = firstLine.Union(secondLine);
        IEnumerable<int> ordered = union.OrderBy(num => num);

        Console.WriteLine("\nResult:");
        foreach (var number in ordered)
        {
            Console.Write("{0} ", number);
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}
