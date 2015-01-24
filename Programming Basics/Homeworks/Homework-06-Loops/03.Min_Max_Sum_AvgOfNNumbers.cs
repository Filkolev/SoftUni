using System;

/* Write a program that reads from the console a sequence of n integer numbers 
 and returns the minimal, the maximal number, the sum and the average of all numbers 
 (displayed with 2 digits after the decimal point). The input starts by the number n 
 (alone in a line) followed by n lines, each holding an integer number. */

class Min_Max_Sum_AvgOfNNumbers
{
    static void Main()
    {
        Console.Write("How many numbers do you wish to enter? ");
        int n;

        while (!int.TryParse(Console.ReadLine(), out n) || n < 1)
        {
            Console.Write("The number you entered isn't valid, please re-enter: ");
        }

        int maxNum = Int32.MinValue;
        int minNum = Int32.MaxValue;
        int sum = 0;        

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter a number [{0}]: ", i + 1);
            int currentNum;

            while (!int.TryParse(Console.ReadLine(), out currentNum))
            {
                Console.Write("The number you entered isn't valid, please re-enter: ");
            }

            maxNum = Math.Max(maxNum, currentNum);
            minNum = Math.Min(minNum, currentNum);
            sum = sum += currentNum;
        }

        double average = (double)sum / n;

        Console.WriteLine("\nResult:\nmin = {0}\nmax = {1}\nsum = {2}\navg = {3:F2}\n",
            minNum, maxNum, sum, average);
    }
}
