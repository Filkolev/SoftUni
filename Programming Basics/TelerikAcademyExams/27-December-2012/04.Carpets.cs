using System;

class Carpets
{
    static void Main()
    {
        int width = int.Parse(Console.ReadLine());

        // print top half
        for (int i = 0; i < width / 2; i++)
        {
            // print dots to the left
            Console.Write(new string('.', width / 2 - 1 - i));

            // print left part of diamonds
            for (int left = 0; left < i + 1; left++)
            {
                if (left % 2 == 0)
                {
                    Console.Write('/');
                }
                else
                {
                    Console.Write(' ');
                }
            }

            // print right part of diamonds
            for (int right = i; right < 2 * i + 1; right++)
            {
                if (right % 2 == 0)
                {
                    Console.Write('\\');
                }
                else
                {
                    Console.Write(' ');
                }
            }

            // print dots to the right
            Console.Write(new string('.', width / 2 - 1 - i));

            Console.WriteLine();
        }

        // print bottom half
        for (int i = 0; i < width / 2; i++)
        {
            // print dots to the left
            Console.Write(new string('.', i));

            // print left part or diamonds
            for (int left = 0; left < width / 2 - i; left++)
            {
                if (left % 2 == 0)
                {
                    Console.Write('\\');
                }
                else
                {
                    Console.Write(' ');
                }
            }

            // print right part of diamonds
            for (int right = width / 2 + i; right < width; right++)
            {
                if (right % 2 == 1)
                {
                    Console.Write('/');
                }
                else
                {
                    Console.Write(' ');
                }
            }

            // print dots to the right
            Console.Write(new string('.', i));

            Console.WriteLine();
        }
    }
}
