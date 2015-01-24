using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/273

class AngryBits
{
    static void Main()
    {
        ushort[] field = new ushort[8];

        for (int i = 0; i < 8; i++)
        {
            field[i] = ushort.Parse(Console.ReadLine());
        }

        int totalScore = 0;
        int totalPigs = 0;

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                int bit = (field[row] >> col) & 1;
                totalPigs += bit;
            }
        }

        int currentRow = 0;
        int currentCol = 0;

        for (int col = 8; col < 16; col++)
        {
            int pigsDestroyed = 0;
            int pathLength = 0;
            bool impact = false;

            for (int row = 0; row < 8; row++)
            {
                int bit = (field[row] >> col) & 1;
                if (bit == 1)
                {
                    currentRow = row;
                    currentCol = col;   

                    while (!impact)
                    {
                        currentRow--;
                        currentCol--;

                        if (currentRow < 0)
                        {
                            currentRow++;
                            currentCol++;                           
                            break;
                        }                        
                        else if (currentCol > 7)
                        {
                            pathLength++;
                            continue;
                        }
                        else
                        {
                            if (((field[currentRow] >> currentCol) & 1) == 1)
                            {
                                Impact(field, currentRow, currentCol, ref pigsDestroyed);
                                impact = true;
                            }

                            pathLength++;                                                        
                        }
                    }

                    while (!impact)
                    {
                        currentCol--;
                        currentRow++;

                        if (currentRow > 7 || currentCol < 0)
                        {
                            break;
                        }
                        else if (currentCol > 7)
                        {
                            pathLength++;
                            continue;
                        }
                        else
                        {
                            if (((field[currentRow] >> currentCol) & 1) == 1)
                            {
                                Impact(field, currentRow, currentCol, ref pigsDestroyed);
                                impact = true;
                            }

                            pathLength++;                           
                        }
                    }
                }

                if (impact)
                {
                    break;
                }                
            }

            int score = pigsDestroyed * pathLength;
            totalPigs -= pigsDestroyed;
            totalScore += score;
        }

        Console.WriteLine("{0} {1}", totalScore, totalPigs == 0 ? "Yes" : "No");
    }

    static void Impact(ushort[] field, int impactRow, int impactCol, ref int pigsDestroyed)
    {
        int startRow = Math.Max(0, impactRow - 1);
        int startCol = Math.Max(0, impactCol - 1);
        int endRow = Math.Min(7, impactRow + 1);
        int endCol = Math.Min(7, impactCol + 1);

        for (int row = startRow; row <= endRow; row++)
        {
            for (int col = startCol; col <= endCol; col++)
            {
                int bit = (field[row] >> col) & 1;
                if (bit == 1)
                {
                    pigsDestroyed++;
                    ushort mask = (ushort)(~(1 << col));
                    field[row] = (ushort)(field[row] & mask);
                }
            }
        }
    }
}
