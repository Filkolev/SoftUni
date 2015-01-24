using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/25

class Lines
{
    static void Main()
    {
        byte[] grid = new byte[8];

        for (int i = 0; i < 8; i++)
        {
            grid[i] = byte.Parse(Console.ReadLine());
        }

        int maxLength = 0;
        int numberOfLines = 0;

        // checking lines down and to the left
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                int bit = (grid[row] >> col) & 1;
                if (bit == 1)
                {
                    int currentLength = 1;

                    bool counted = false; // If the first method discovers a line of length 1, the second shouldn't double-count it
                    CheckDown(grid, col, row, ref maxLength, currentLength, ref numberOfLines, ref counted);
                    CheckLeft(grid, ref col, row, ref maxLength, currentLength, ref numberOfLines, counted);
                }
            }
        }

        Console.WriteLine(maxLength);
        Console.WriteLine(numberOfLines);
    }

    // A line is surrounded by 0's or by the grid's borders
    static void CheckLeft(byte[] grid, ref int col, int row, ref int maxLength, int currentLength, ref int numberOfLines, bool counted)
    {
        // Check if we're in the middle of a line
        if (col != 0)
        {
            int rightBit = (grid[row] >> col - 1) & 1;
            if (rightBit == 1)
            {
                return;
            }
        }

        int currentCol = col + 1;

        while (currentCol < 8)
        {
            int bit = (grid[row] >> currentCol) & 1;

            if (bit == 1)
            {
                currentLength++;
            }
            else
            {
                break;
            }

            currentCol++;
        }

        if (currentLength == maxLength)
        {
            if (currentLength != 1 || !counted)
            {
                numberOfLines++;
            }
        }
        else if (currentLength > maxLength)
        {
            maxLength = currentLength;
            numberOfLines = 1;
        }
    }

    static void CheckDown(byte[] grid, int col, int row, ref int maxLength, int currentLength, ref int numberOfLines, ref bool counted)
    {
        // Check if we're in the middle of a line
        if (row != 0)
        {
            int upperBit = (grid[row - 1] >> col) & 1;

            if (upperBit == 1)
            {
                return;
            }
        }

        int currentRow = row + 1;

        while (currentRow < 8)
        {
            int bit = (grid[currentRow] >> col) & 1;
            if (bit == 1)
            {
                currentLength++;
            }
            else
            {
                break;
            }

            currentRow++;
        }

        if (currentLength == maxLength)
        {
            numberOfLines++;
            if (currentLength == 1)
            {
                counted = true; // denotes that a single cell was counted as a line of length 1
            }
        }
        else if (currentLength > maxLength)
        {
            maxLength = currentLength;
            numberOfLines = 1;
            if (currentLength == 1)
            {
                counted = true;
            }
        }
    }
}
