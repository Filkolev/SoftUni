namespace _04.Exugs
{
    using System;

    public class ExRugs
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int widthOfX = int.Parse(Console.ReadLine());
            int totalSize = (size * 2) + 1;

            char[][] rug = new char[totalSize][];

            for (int i = 0; i < totalSize; i++)
            {
                rug[i] = new char[totalSize];

                for (int j = 0; j < totalSize; j++)
                {
                    rug[i][j] = '.';
                }
            }

            for (int row = 0; row < totalSize; row++)
            {
                int leftLeftBoundary = row - (widthOfX / 2) - 1;
                int rightLeftBoundary = leftLeftBoundary + widthOfX + 1;

                int rightRightBoundary = totalSize + (widthOfX / 2) - row;
                int leftRightBoundary = rightRightBoundary - widthOfX - 1;

                for (int col = 0; col < totalSize; col++)
                {
                    if (leftLeftBoundary == leftRightBoundary && leftLeftBoundary == col)
                    {
                        rug[row][col] = 'X';
                    }
                    else if (rightLeftBoundary == leftRightBoundary && rightLeftBoundary == col)
                    {
                        rug[row][col] = 'X';
                    }
                    else if (rightLeftBoundary == rightRightBoundary && rightLeftBoundary == col)
                    {
                        rug[row][col] = 'X';
                    }
                    else if (leftLeftBoundary == rightRightBoundary && leftLeftBoundary == col)
                    {
                        rug[row][col] = 'X';
                    }
                    else if (leftLeftBoundary == col && (col < leftRightBoundary || col > rightRightBoundary))
                    {
                        rug[row][col] = '\\';
                    }
                    else if (rightLeftBoundary == col && (col < leftRightBoundary || col > rightRightBoundary))
                    {
                        rug[row][col] = '\\';
                    }
                    else if (leftRightBoundary == col && (col < leftLeftBoundary || col > rightLeftBoundary))
                    {
                        rug[row][col] = '/';
                    }
                    else if (rightRightBoundary == col && (col < leftLeftBoundary || col > rightLeftBoundary))
                    {
                        rug[row][col] = '/';
                    }
                    else if (leftLeftBoundary < col && col < rightLeftBoundary)
                    {
                        rug[row][col] = '#';
                    }
                    else if (leftRightBoundary < col && col < rightRightBoundary)
                    {
                        rug[row][col] = '#';
                    }
                    else if (leftRightBoundary < rightLeftBoundary && leftRightBoundary == col)
                    {
                        rug[row][col] = '#';
                    }
                }
            }

            PrintRug(rug);
        }

        private static void PrintRug(char[][] rug)
        {
            foreach (char[] row in rug)
            {
                foreach (char ch in row)
                {
                    Console.Write(ch);
                }

                Console.WriteLine();
            }
        }
    }
}
