using System;
using System.Collections.Generic;
using System.Linq;

/* We have a report that holds dates, web site URLs and load times (in seconds) in the 
 same format like in the examples below. Your tasks is to calculate the average load 
 time for each URL. Print the URLs in the same order as they first appear in the input 
 report. Print the output in the format given below. Use double floating-point precision. */


class AverageLoadTimeCalculator
{
    static void Main()
    {
       // Store the report data in a list of arrays
        List<string[]> data = new List<string[]>();

        Console.WriteLine("Please enter the report:");

        while (true)
        {
            string input = Console.ReadLine();

            if (input.Length == 0) // Stop the loop when the report is over
            {
                break; 
            }

            data.Add(input.Split());
        }

        // Find and store in a separate list all websites
        List<string> websites = new List<string>();

        for (int row = 0; row < data.Count; row++)
        {
            bool uniqueSite = true;

            for (int websiteIndex = 0; websiteIndex < websites.Count; websiteIndex++)
            {
                if (data[row][2] == websites[websiteIndex])
                {
                    uniqueSite = false;
                }
            }

            if (uniqueSite)
            {
                websites.Add(data[row][2]);
            }
        }

        // Calculate and print the average load times
        Console.WriteLine("\nAverage load time per site:");
        foreach (var site in websites)
        {
            double sumOfLoadTimes = 0;
            int countOfLoads = 0;

            for (int row = 0; row < data.Count; row++)
            {
                if (site == data[row][2])
                {
                    countOfLoads++;
                    sumOfLoadTimes += double.Parse(data[row][3]);
                }
            }

            double averageLoadTime = sumOfLoadTimes / countOfLoads;

            Console.WriteLine("{0} -> {1}", site, averageLoadTime);
        }

        Console.WriteLine();
    }
}
