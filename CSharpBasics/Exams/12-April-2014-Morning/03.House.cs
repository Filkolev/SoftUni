using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/57

class House
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        // Top of roof
        Console.WriteLine("{0}*{0}", new string('.', size / 2));

        // Roof
        for (int i = 1; i < size / 2; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', size / 2 - i), new string('.', 1 + 2 * (i - 1)));
        }

        // Bottom of roof
        Console.WriteLine("{0}", new string('*', size));

        // Rest of the house
        for (int i = 0; i < size / 2 - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', size / 4), new string('.', size - 2 - size / 4 - size / 4));
        }

        // Base
        Console.WriteLine("{0}{1}{0}", new string('.', size / 4), new string('*', size - size / 4 - size / 4));
    }
}
