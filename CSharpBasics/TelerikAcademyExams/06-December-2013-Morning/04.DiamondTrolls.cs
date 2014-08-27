using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/511

class DiamondTrolls
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        for (int height = 0; height < (6 + ((size - 3) / 2) * 3 - size); height++)
        {
            for (int width = 0; width < size * 2 + 1; width++)
            {
                if (width == size)
                {
                    Console.Write('*');
                }

                else if (height == (6 + ((size - 3) / 2) * 3) - 1 - size)
                {
                   Console.Write('*');
                }

                else if (width + height == size / 2 + 1)
                {
                    Console.Write('*');
                }

                else if (size * 2 - width + height == size / 2 + 1)
                {
                     Console.Write('*');
                }

                else if (height == 0 && width >= size / 2 + 1 && width <= size * 2 - size / 2 - 1)
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

        for (int height = 0; height < size; height++)
        {
            for (int width = 0; width < 2 * size + 1; width++)
            {
                if (width == size)
                {
                    Console.Write('*');
                }

                else if (width - 1 == height)
                {
                    Console.Write('*');
                }

                else if (2 * size - width - 1 == height)
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
