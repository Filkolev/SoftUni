using System;
using System.Collections.Generic;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/49

class CrossingSequences
{
    static void Main()
    {
        // Get input for the Tribonacci sequence and save all members in a list
        int t1 = int.Parse(Console.ReadLine());
        int t2 = int.Parse(Console.ReadLine());
        int t3 = int.Parse(Console.ReadLine());        

        List<int> tribonacci = new List<int>();
        tribonacci.Add(t1);
        tribonacci.Add(t2);
        tribonacci.Add(t3);

        int tn = t1 + t2 + t3;             
        while (tn <= 1000000)
        {            
            tribonacci.Add(tn);
            t1 = t2;
            t2 = t3;
            t3 = tn;
            tn = t1 + t2 + t3;
        }

        // Get input for the number spiral and save all members to a list
        int spiralStart = int.Parse(Console.ReadLine());
        int spiralStep = int.Parse(Console.ReadLine());
        int step = spiralStep;

        List<int> spiral = new List<int>();
        spiral.Add(spiralStart);

        for (int i = 1; ; i++)
        {                      
            int sn = spiralStart + step;
            if (sn > 1000000)
            {
                break;
            }

            spiral.Add(sn);

            spiralStart = sn;

            if (i % 2 == 0)
            {
                step += spiralStep;
            }
        }

        // Loop through both lists and check if they cross
        for (int i = 0; i < tribonacci.Count; i++)
        {
            for (int j = 0; j < spiral.Count; j++)
            {
                if (tribonacci[i] == spiral[j])
                {
                    Console.WriteLine(tribonacci[i]);
                    return;
                }
            }
        }

        Console.WriteLine("No");        
    }
}
