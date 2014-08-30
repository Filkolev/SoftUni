using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/269

class BitBall
{
    static void Main()
    {
        int[] top = new int[8];
        int[] bottom = new int[8];

        int topScore = 0;
        int bottomScore = 0;

        for (int i = 0; i < 8; i++)
        {
            top[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < 8; i++)
        {
            bottom[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < 8; i++)
        {
            int mask = top[i] & bottom[i];
            top[i] = top[i] & ~mask;
            bottom[i] = bottom[i] & ~mask;
        }

        for (int row = 0; row < 8; row++)
        {
            for (int position = 0; position < 8; position++)
            {
                int currentTopBit = (top[row] >> position) & 1;
                int currentBottomBit = (bottom[row] >> position) & 1;

                if (currentTopBit == 1)
                {
                    bool goal = true;

                    for (int i = row + 1; i < 8; i++)
                    {
                        int opponentPresent = (bottom[i] >> position) & 1;
                        int teammatePresent = (top[i] >> position) & 1;
                        if ((opponentPresent | teammatePresent) == 1)
                        {
                            goal = false;
                            break;
                        }
                    }

                    if (goal)
                    {
                        topScore++;
                    }
                }

                else if (currentBottomBit == 1)
                {
                    bool goal = true;

                    for (int i = row - 1; i >= 0; i--)
                    {
                        int opponentPresent = (top[i] >> position) & 1;
                        int teammatePresent = (bottom[i] >> position) & 1;
                        if ((opponentPresent | teammatePresent) == 1)
                        {
                            goal = false;
                            break;
                        }
                    }

                    if (goal)
                    {
                        bottomScore++;
                    }
                }
            }
        }

        Console.WriteLine("{0}:{1}", topScore, bottomScore);
    }
}
