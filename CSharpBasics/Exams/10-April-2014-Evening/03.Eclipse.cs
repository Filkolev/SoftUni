using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/26

class Eclipse
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        for (int i = 0; i < size; i++)
        {
            if (i == 0 || i == size - 1)
            {
                Console.WriteLine(" {0}{1}{0} ", new string('*', 2 * size - 2), new string(' ', size + 1));
            }

            else if (i == size/2)
            {
                Console.WriteLine("*{0}*{1}*{0}*", new string('/', 2 * size - 2), new string('-', size - 1));
            }

            else
            {
                Console.WriteLine("*{0}*{1}*{0}*", new string('/', 2 * size - 2), new string(' ', size - 1));
            }
        }
    }
}
