using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/47

class NewHouse
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        // Print roof
        for (int i = 0; i < N/2+1; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('-', N/2 - i), new string('*', 1 + 2 * i));
        }

        // Print rest of house
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine("|{0}|", new string('*', N - 2));
        }
    }
}
