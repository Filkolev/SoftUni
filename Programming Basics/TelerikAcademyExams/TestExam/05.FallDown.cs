using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/10

class FallDown
{
    static void Main()
    {
        byte[] grid = new byte[8];

        for (int i = 0; i < 8; i++)
        {
            grid[i] = byte.Parse(Console.ReadLine());
        }

        for (byte row = 7; row > 0; row--)
        {
            for (byte col = 0; col < 8; col++)
            {
                byte bit = (byte)((grid[row] >> col) & 1);

                if (bit == 0)
                {
                    bool finished = false;

                    for (int upperRow = row - 1; upperRow >= 0; upperRow--)
                    {

                        byte upperBit = (byte)((grid[upperRow] >> col) & 1);

                        if (upperBit == 1)
                        {
                            grid[upperRow] ^= (byte)(1 << col);
                            grid[row] ^= (byte)(1 << col);
                            finished = true;
                        }

                        if (upperRow == 0)
                        {
                            finished = true;
                        }

                        if (finished)
                        {
                            break;
                        }
                    }

                    if (finished)
                    {
                        continue;
                    }
                }
            }
        }

        foreach (var num in grid)
        {
            Console.WriteLine(num); 
        }
    }
}
