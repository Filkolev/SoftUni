using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/78

class WineGlass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}\\{1}/{0}", new string('.', i), new string('*', n - 2 - 2 * i));
        }

        int stem;

        if (n < 12)
        {
            stem = n / 2 - 1;
        }

        else
        {
            stem = n / 2 - 2;
        }

        for (int i = 0; i < stem; i++)
        {
            Console.WriteLine("{0}||{0}", new string('.', n / 2 - 1));   
        }

        for (int i = 0; i < n - n / 2 - stem; i++)
        {
            Console.WriteLine("{0}", new string('-', n));
        }
    }
}
