using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/516

class KaspichaniaBoats
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int height = 0; height < 6 + ((n - 3) / 2) * 3; height++)
        {
            for (int width = 0; width < 2 * n + 1; width++)
            {
                if (height == n || width == n)
                {
                    Console.Write('*');
                }

                else if (height + width == n || 2 * n - width + height == n)
                {
                    Console.Write('*');
                }

                else if (height > n && width == height - n)
                {
                    Console.Write('*');
                }

                else if (height > n &&  2 * n - width == height - n)
                {
                     Console.Write('*');
                }

                else if (height == 6 + ((n - 3) / 2) * 3 - 1 && width >= height - n && 2 * n - width >= height - n)
                {
                    Console.Write('*');
                }

                else
                {
                    Console.Write('.');
                }
            }

            Console.WriteLine();
        }
    }
}
