using System;

class Plane
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int outerDots = 3 * size / 2;
        int innerDots = -1;

        for (int i = 0; i < size + 1; i++)
        {
            if (i == 0)
            {
                Console.WriteLine("{0}*{0}", new string('.', outerDots));
            }

            else
            {
                Console.WriteLine("{0}*{1}*{0}", new string('.', outerDots), new string('.', innerDots));
            }

            outerDots--;
            innerDots += 2;

            if (i >= size - size / 2 + 1)
            {
                outerDots--;
                innerDots += 2;
            }
        }

        char[,] middle = new char[size / 2, 3 * size];

        for (int i = 0; i < size / 2; i++)
        {
            for (int j = 0; j < 3 * size; j++)
            {
                middle[i, j] = '.';
            }
        }

        int row = 0;
        int col = 0;

        while (row < size / 2)
        {
            middle[row, col] = '*';
            row++;
        }

        row--;
        col += 2;

        while (row > 0)
        {
            middle[row, col] = '*';
            row--;
            col += 2;
        }

        while (row < size / 2)
        {
            middle[row, col] = '*';
            row++;
        }

        row = 0;
        col = 3 * size - 1;
        while (row < size / 2)
        {
            middle[row, col] = '*';
            row++;
        }

        row--;
        col -= 2;

        while (row >= 0)
        {
            middle[row, col] = '*';
            row--;
            col -= 2;
        }

        col += 2;
        row++;

        while (row < size / 2)
        {
            middle[row, col] = '*';
            row++;
        }


        for (int i = 0; i < size / 2; i++)
        {
            for (int j = 0; j < 3 * size; j++)
            {
                Console.Write(middle[i, j]);
            }

            Console.WriteLine();
        }

        outerDots = size - 1;
        innerDots = size;
        for (int i = 0; i < size; i++)
        {
            if (i == size - 1)
            {
                Console.WriteLine("{0}", new string('*', size * 3));
            }

            else
            {
                Console.WriteLine("{0}*{1}*{0}", new string('.', outerDots), new string('.', innerDots));
            }

            outerDots--;
            innerDots += 2;
        }
    }
}
