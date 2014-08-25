using System;
using System.Linq;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/102

class SequenceOfKNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();

        string[] splitInput = input.Split();

        int k = int.Parse(Console.ReadLine());

        if (k == 1)
        {
            return;
        }

        int numberOfChecked = 0;

        for (int j = 0; j <= splitInput.Length - k;)
			{
			 
                string[] subset = splitInput.Skip(j).Take(k).ToArray();
                int countOfEqual = 1;
                for (int m = 0; m < subset.Length - 1; m++)
                {
                    if (subset[m] == subset[m + 1])
                    {
                        countOfEqual++;
                    }
                }

                if (countOfEqual == k)
                {
                    if (j == splitInput.Length - k)
                    {
                        return;
                    }

                    j += k;
                    
                    if (j > splitInput.Length)
                    {
                        break;
                    }

                    else
                    {
                        numberOfChecked = j;
                    }

                    continue;
                }

                else
                {
                    Console.Write("{0} ", splitInput[j]);
                    j++;
                    numberOfChecked++;
                }                
            }

        for (int i = numberOfChecked; i < splitInput.Length; i++)
        {
            Console.Write("{0} ", splitInput[i]);
        }
    }
}
