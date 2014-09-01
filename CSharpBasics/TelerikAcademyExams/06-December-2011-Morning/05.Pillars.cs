using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/15

class Pillars
{
    static void Main()
    {
        byte[] grid = new byte[8];

        for (int i = 0; i < 8; i++)
        {
            grid[i] = byte.Parse(Console.ReadLine());
        }

        bool found = false;

        for (int column = 7; column >= 0; column--)
        {
            int leftBits = 0;
            int rightBits = 0;          

            int leftStart = column + 1;
            while (leftStart < 8)
            {
                leftBits += CalculateBitsAtColumn(grid, leftStart);
                leftStart++;
            }

            int rightStart = column - 1;
            while (rightStart >= 0)
            {
                rightBits += CalculateBitsAtColumn(grid, rightStart);
                rightStart--;
            }

            if (rightBits == leftBits)
            {
                Console.WriteLine(column);
                Console.WriteLine(rightBits);
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("No");
        }
    }

    static int CalculateBitsAtColumn(byte[] grid, int column)
    {
        int bitsCount = 0;

        for (int row = 0; row < 8; row++)
        {
            int bit = (grid[row] >> column) & 1;
            bitsCount += bit;
        }

        return bitsCount;
    }
}
