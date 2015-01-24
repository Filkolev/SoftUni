using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/506

class Eggcelent
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        for (int i = 0; i < size; i++)
        {
            int outerDots = Math.Max(size + 1 - 2 * i, 1);            
            int innerDots = Math.Min(size - 3 + 4 * i, 3 * size - 3);

            if (i == 0)
            {
                Console.WriteLine("{0}{1}{0}", new string('.', outerDots), new string('*', size - 1));
            }

            else if (i == size - 1)
            {
                Console.Write(".*");
                for (int j = 0; j < 3 * size - 3; j++)
                {
                    if (j % 2 == 0)
                    {
                        Console.Write("@");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                    
                }
                Console.Write("*.\n");
            }

            else
            {
                Console.WriteLine("{0}*{1}*{0}", new string('.', outerDots), new string('.', innerDots));
            }
        }

        for (int i = size - 1; i >= 0; i--)
        {
            int outerDots = Math.Max(size + 1 - 2 * i, 1);
            int innerDots = Math.Min(size - 3 + 4 * i, 3 * size - 3);

            if (i == size - 1)
            {
                Console.Write(".*");
                for (int j = 0; j < 3 * size - 3; j++)
                {
                    if (j % 2 == 0)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("@");
                    }

                }
                Console.Write("*.\n");
            }

            else if (i == 0)
            {
                Console.WriteLine("{0}{1}{0}", new string('.', outerDots), new string('*', size - 1));
            }

            else
            {
                Console.WriteLine("{0}*{1}*{0}", new string('.', outerDots), new string('.', innerDots));
            }
        }
    }
}
