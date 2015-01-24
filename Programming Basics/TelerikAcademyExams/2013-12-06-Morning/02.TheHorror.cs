using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/509

class TheHorror
{
    static void Main()
    {
        string input = Console.ReadLine();
        int count = 0;
        int sum = 0;

        for (int i = 0; i < input.Length; i += 2)
        {
            if (input[i] >= '0' && input[i] <= '9')
            {
                sum += input[i] - '0';
                count++;
            }
        }

        Console.WriteLine("{0} {1}", count, sum);
    }
}
