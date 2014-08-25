using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/10

class BitwiseOperations
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int input = int.Parse(Console.ReadLine());

            int result = 0;

            while (input > 0)
            {
                int bit = input & 1;
                result = (result << 1) | bit;
                input = input >> 1;
            }

            Console.WriteLine(result);              
        }
    }
}
