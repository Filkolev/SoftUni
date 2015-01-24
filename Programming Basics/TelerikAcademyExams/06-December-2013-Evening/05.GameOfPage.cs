using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/517

class GameOfPage
{
    static void Main()
    {
        string[] inputLines = new string[16];

        for (int i = 0; i < 16; i++)
        {
            inputLines[i] = Console.ReadLine();
        }

        char[,] tray = new char[16, 16];

        for (int row = 0; row < 16; row++)
        {
            for (int col = 0; col < 16; col++)
            {
                tray[row, col] = inputLines[row][col];
            }
        }

        decimal price = 0;

        string question = null;

        while (question != "paypal")
        {
            question = Console.ReadLine();

            if (question == "what is")
            {
                int checkRow = int.Parse(Console.ReadLine());
                int checkColumn = int.Parse(Console.ReadLine());

                if (tray[checkRow, checkColumn] == '0')
                {
                    Console.WriteLine("smile");
                }
                else
                {
                    Console.WriteLine(checkLocation(checkRow, checkColumn, tray));
                }
            }

            if (question == "buy")
            {
                int checkRow = int.Parse(Console.ReadLine());
                int checkColumn = int.Parse(Console.ReadLine());

                if (checkLocation(checkRow, checkColumn, tray) == "cookie")
                {
                    price += 1.79m;
                    for (int r = checkRow - 1; r <= checkRow + 1; r++)
                    {
                        for (int c = checkColumn - 1; c <= checkColumn + 1; c++)
                        {
                            tray[r, c] = '0';
                        }
                    }
                }

                else if (checkLocation(checkRow, checkColumn, tray) == "broken cookie" || checkLocation(checkRow, checkColumn, tray) == "cookie crumb")
                {
                    Console.WriteLine("page");
                }
            }
        }

        Console.WriteLine("{0:F2}", price);

    }

    public static string checkLocation(int row, int column, char[,] tray)
    {
        if (tray[row,column] == '0')
        {
            return "smile";
        }

        int upperRow = row - 1;
        if (row == 0)
        {
            upperRow++;
        }

        int lowerRow = row + 1;
        if (row == 15)
        {
            lowerRow--;
        }

        int leftcolumn = column - 1;
        if (column == 0)
        {
            leftcolumn++;
        }

        int rightColumn = column + 1;
        if (column == 15)
        {
            rightColumn--;
        }

        int sum = 0;

        for (int r = upperRow; r <= lowerRow; r++)
        {
            for (int c = leftcolumn; c <= rightColumn; c++)
            {
                if (tray[r, c] == '1')
                {
                    sum++;
                }
            }
        }

        if (sum == 9)
        {
            return "cookie";
        }

        else if (sum == 1 && tray[row, column] == '1')
        {
            return "cookie crumb";
        }

        else
        {
            return "broken cookie";
        }        
    }
}
