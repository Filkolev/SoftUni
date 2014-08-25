using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/5

class DrawFigure
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        string[] rows = new string[N / 2 + 1];

        for (int i = 0; i < N / 2 + 1; i++)
        {
            rows[i] = new string('.', i) + new string('*', N - 2 * i)  + new string('.', i);
            Console.WriteLine(rows[i]);
        }

        for (int i = 0; i < N/2; i++)
        {
            Console.WriteLine(rows[N / 2 - i - 1]);
        }
    }
}
