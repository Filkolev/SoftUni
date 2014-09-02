using System;
using System.Collections.Generic;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/9

class OddNumber
{
    static void Main()
    {
        Dictionary<long, int> values = new Dictionary<long, int>();

        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            long currentNum = long.Parse(Console.ReadLine());
            bool found = values.ContainsKey(currentNum);
            if (!found)
            {
                values.Add(currentNum, 1);
            }
            else
            {
                values[currentNum]++;
            }
        }

        foreach (var item in values)
        {
            if (item.Value % 2 == 1)
            {
                Console.WriteLine(item.Key);
                break;
            }
        }
    }
}
