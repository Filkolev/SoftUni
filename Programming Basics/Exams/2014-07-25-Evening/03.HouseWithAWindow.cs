using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/179

class HouseWithAWindow
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            if (i == 0)
            {
                Console.WriteLine("{0}*{0}", new string('.', N - 1));
            }            

            else
            {
                Console.WriteLine("{0}*{1}*{0}", new string('.', N - 1 - i), new string ('.', 2 * i - 1));
            }
        }

        for (int i = 0; i < N + 2; i++)
        {
            if (i == 0 || i == N + 1)
            {
                Console.WriteLine(new string('*', 2 * N - 1));  
            }

            else if (i < (N + 2 - N / 2) / 2 || i >= (N + 2 - N / 2) / 2 + N / 2)
            {
                Console.WriteLine("*{0}*", new string('.', 2 * N - 3));
            }

            else
            {
                Console.WriteLine("*{0}{1}{0}*", new string('.', (N + 2) / 2 - 1) , new string('*', N - 3));
            }
        }
    }
}
