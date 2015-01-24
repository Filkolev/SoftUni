using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/507

class NaBabaMiSmetalnika
{
    static void Main()
    {
        int width = int.Parse(Console.ReadLine());

        uint[] rows = new uint[8];

        for (int i = 0; i < 8; i++)
        {
            uint currentNum = uint.Parse(Console.ReadLine());
            rows[i] = currentNum;
        }

        string command = Console.ReadLine();

        while (command != "stop")
        {
            if (command == "reset")
            {
                for (int i = 0; i < 8; i++)
                {
                    MoveBits(rows, "left", width, i, width - 1);
                }
            }

            else if (command == "left")
            {
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());
                MoveBits(rows, command, width, row, col);
            }

            else if (command == "right")
            {
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());
                MoveBits(rows, command, width, row, col);
            }

            command = Console.ReadLine();
        }

        ulong sum = 0u;
        for (int i = 0; i < 8; i++)
        {
            sum += rows[i];
        }

        int emptyColumns = GetEmptyColumns(rows, width);
        ulong result = sum * (ulong)emptyColumns;
        Console.WriteLine(result);
    }

    static void MoveBits(uint[] rows, string direction, int width, int row, int col)
    {
        uint currentNumber = rows[row];

        if (direction == "left")
        {
            int startBit = Math.Max(0, width - col - 1);
            int endBit = width - 1;

            if (startBit < endBit)
            {
                int bitsToMove = GetBitCount(currentNumber, startBit, endBit);

                uint leftMask = (uint)((1 << bitsToMove) - 1);
                leftMask = leftMask << (width - bitsToMove);

                uint rightMask = (uint)((1 << startBit) - 1);
                if (rightMask < 0)
                {
                    rightMask = 0;
                }

                rightMask = currentNumber & rightMask;
                rows[row] = leftMask | rightMask;
            }

        }

        else // direction == "right"
        {
            int startBit = 0;
            int endBit = Math.Min(width - col - 1, width - 1);

            if (endBit > 0)
            {
                int bitsToMove = GetBitCount(currentNumber, startBit, endBit);

                uint leftMask = currentNumber >> Math.Min(31, endBit + 1);
                leftMask = leftMask << (endBit + 1);

                uint rightMask = (uint)((1 << bitsToMove) - 1);

                rows[row] = leftMask | rightMask;
            }

        }

    }


    static int GetEmptyColumns(uint[] smetalo, int width)
    {
        int countEmptyCols = 0;

        for (int col = 0; col < width; col++)
        {
            bool empty = true;

            for (int row = 0; row < 8; row++)
            {
                uint bit = (smetalo[row] >> col) & 1;

                if (bit == 1)
                {
                    empty = false;
                    break;
                }
            }

            if (empty)
            {
                countEmptyCols++;
            }
        }

        return countEmptyCols;
    }

    static int GetBitCount(uint number, int startCol, int endCol)
    {
        int count = 0;

        for (int i = startCol; i <= endCol; i++)
        {
            uint bit = (number >> i) & 1;
            count += (int)bit;
        }

        return count;
    }
}
