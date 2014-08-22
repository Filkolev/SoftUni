using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/36

class TheExplorer
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        // Array to store the rows of the diamond
        string[] rows = new string[n / 2 + 1];

        // Draw the top half of the diamond
        for (int i = 0; i < n / 2 + 1; i++)
        {
            if (i == 0)
            {
                // First row (top of the figure)
                rows[i] = new string('-', n / 2) + "*" + new string('-', n / 2);
            }

            else
            {
                rows[i] = new string('-', n / 2 - i) + "*" + new string('-', 1 + 2 * (i - 1)) + "*" + new string('-', n / 2 - i);
            }

            Console.WriteLine(rows[i]);
        }

        // Draw bottom half of the figure by drawing the top rows in reverse order.
        // Do not draw the middle again, hence i starts from 1, not 0.
        for (int i = 1; i <= n / 2; i++)
        {
            Console.WriteLine(rows[n / 2 - i]);
        }
    }
}
