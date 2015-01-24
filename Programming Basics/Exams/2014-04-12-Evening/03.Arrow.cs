using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/67

class Arrow
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        // top
        Console.WriteLine("{0}{1}{0}", new string('.', n/2), new string('#', n));

        // middle body
        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine("{0}#{1}#{0}", new string('.', n / 2), new string('.', n - 2));
        }

        // start of arrow's head
        Console.WriteLine("{0}#{1}#{0}", new string('#', n / 2), new string('.', n - 2));

        // head
        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine("{0}#{1}#{0}", new string('.', i + 1), new string('.', 2 * n - 5 - 2 * i));
        }

        // tip
        Console.WriteLine("{0}#{0}", new string('.', n - 1));
    }
}
