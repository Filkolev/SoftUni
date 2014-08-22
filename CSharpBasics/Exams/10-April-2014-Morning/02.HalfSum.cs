using System;

// Find problem here: http://judge.softuni.bg/Contests/Practice/DownloadResource/14

class HalfSum
{
    static void Main()
    {       
        int n = int.Parse(Console.ReadLine());
       
        int firstSum = 0;
        int secondSum = 0;
        
        for (int i = 0; i < n; i++)
        {
            firstSum += int.Parse(Console.ReadLine());
        }
       
        for (int i = 0; i < n; i++)
        {
            secondSum += int.Parse(Console.ReadLine());
        }
       
        if (firstSum == secondSum)
        {            
            Console.WriteLine("Yes, sum=" + firstSum);
        }

        else
        {            
            Console.WriteLine("No, diff=" + Math.Abs(firstSum-secondSum));
        }
    }
}
