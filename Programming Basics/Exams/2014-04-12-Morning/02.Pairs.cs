using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/55

class Pairs
{
    static void Main()
    {
        string input = Console.ReadLine();

        string[] splitInput = input.Split();
        int[] numbers = new int[splitInput.Length];
        
        for (int i = 0; i < splitInput.Length; i++)
        {
            numbers[i] = Convert.ToInt32(splitInput[i]);
        }

        int maxDiff = Int32.MinValue;
        int currentSum = 0;      
        
        for (int i = 0; i < numbers.Length - 3; i += 2)
        {
           currentSum = numbers[i] + numbers[i + 1];
           int nextSum = numbers[i + 2] + numbers[i + 3];

           maxDiff = Math.Max(maxDiff, Math.Abs(currentSum - nextSum));
        }


        if (maxDiff == 0)
        {
            Console.WriteLine("Yes, value={0}", currentSum); 
        }

        else if (numbers.Length == 2)
        {
            Console.WriteLine("Yes, value={0}", numbers[0] + numbers[1]);  
        }

        else
        {
            Console.WriteLine("No, maxdiff={0}", maxDiff);
        }
    }
}
