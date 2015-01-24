using System;
using System.Collections.Generic;

class OddOrEvenCounter
{
    static void Main()
    {
        int numberOfSets = int.Parse(Console.ReadLine());
        int numbersPerSet = int.Parse(Console.ReadLine());
        string checkValue = Console.ReadLine();

        List<int> resultsPerSet = new List<int>();

        for (int i = 0; i < numberOfSets; i++)
        {
            int found = 0;

            for (int j = 0; j < numbersPerSet; j++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                
                if (checkValue == "odd" && (currentNum % 2 == 1))
                {
                    found++;
                }
                else if (checkValue == "even" && (currentNum % 2 == 0))
                {
                    found++;
                }
            }

            resultsPerSet.Add(found);
        }

        int maxValue = 0;
        int maxIndex = 0;

        for (int i = 0; i < resultsPerSet.Count; i++)
        {
            if (resultsPerSet[i] > maxValue)
            {
                maxValue = resultsPerSet[i];
                maxIndex = i + 1;
            }
        }

        if (maxValue == 0)
        {
            Console.WriteLine("No");
        }
        else
        {
            switch (maxIndex)
            {
                case 1: Console.Write("First"); break;
                case 2: Console.Write("Second"); break;
                case 3: Console.Write("Third"); break;
                case 4: Console.Write("Fourth"); break;
                case 5: Console.Write("Fifth"); break;
                case 6: Console.Write("Sixth"); break;
                case 7: Console.Write("Seventh"); break;
                case 8: Console.Write("Eight"); break;
                case 9: Console.Write("Ninth"); break;
                case 10: Console.Write("Tenth"); break;
            }

            Console.WriteLine(" set has the most {1} numbers: {0}", maxValue, checkValue);
        }
    }
}
