using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/104

class Disk
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int R = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                bool insideDisk = (i - N / 2) * (i - N / 2) + (j - N / 2) * (j - N / 2) <= R * R;
                
                if (insideDisk)
                {
                    Console.Write("*");
                }

                else
                {
                    Console.Write(".");
                }                
            }

            Console.WriteLine();
        }
    }
}
