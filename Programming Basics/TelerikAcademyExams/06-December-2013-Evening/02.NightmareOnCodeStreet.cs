using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/514

class NightmareOnCodeStreet
{
    static void Main()
    {
        string input = Console.ReadLine();

        int count = 0;

        long sum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 == 1)
            {   
                if (input[i] >= '0' && input[i] <= '9')
                {
                    sum += (input[i] - '0');
                    count++;
                }               
            }
        }

        Console.Write("{0} {1}", count, sum);
    }
}
