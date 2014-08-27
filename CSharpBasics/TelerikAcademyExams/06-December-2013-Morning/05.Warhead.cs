using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/512

class Warhead
{
    static void Main()
    {
        char[,] circuit = new char[16, 16];

        for (int row = 0; row < 16; row++)
        {
            string currrentLine = Console.ReadLine();

            for (int column = 0; column < 16; column++)
            {
                circuit[row, column] = currrentLine[column];
            }
        }

        int redCapacitors = 0;
        int blueCapacitors = 0;        

        bool gameOver = false;
        string currentCommand = "";

        while (!gameOver)
        {
            currentCommand = Console.ReadLine();

            if (currentCommand == "hover")
            {
                int currentRow = int.Parse(Console.ReadLine());
                int currentCol = int.Parse(Console.ReadLine());

                if (circuit[currentRow, currentCol] == '0')
                {
                    Console.WriteLine("-");
                }

                else
                {
                    Console.WriteLine("*");
                }
            }

            if (currentCommand == "operate")
            {
                int currentRow = int.Parse(Console.ReadLine());
                int currentCol = int.Parse(Console.ReadLine());

                if (capacitorCheck(circuit, currentRow, currentCol))
                {                 
                    circuit[currentRow - 1, currentCol - 1] = '0';
                    circuit[currentRow - 1, currentCol] = '0';
                    circuit[currentRow - 1, currentCol + 1] = '0';
                    circuit[currentRow, currentCol - 1] = '0';
                    circuit[currentRow, currentCol + 1] = '0';
                    circuit[currentRow + 1, currentCol - 1] = '0';
                    circuit[currentRow + 1, currentCol] = '0';
                    circuit[currentRow + 1, currentCol + 1] = '0';
                }

                if (circuit[currentRow, currentCol] == '1')
                {
                    gameOver = true;
                    Console.WriteLine("missed");

                    for (int row = 1; row <= 14; row++)
                    {
                        for (int column = 1; column <= 14; column++)
                        {
                            if (column <= 7 && capacitorCheck(circuit, row, column))
                            {
                                redCapacitors++;
                            }

                            else if (column > 7 && capacitorCheck(circuit, row, column))
                            {
                                blueCapacitors++;
                            }
                        }
                    }

                    Console.WriteLine(redCapacitors + blueCapacitors);
                    Console.WriteLine("BOOM");
                }
            }

            if (currentCommand == "cut")
            {
                string wire = Console.ReadLine();

                for (int row = 1; row <= 14; row++)
                {
                    for (int column = 1; column <= 14; column++)
                    {
                        if (column <= 7 && capacitorCheck(circuit, row, column))
                        {
                            redCapacitors++;
                        }

                        else if (column > 7 && capacitorCheck(circuit, row, column))
                        {
                            blueCapacitors++;
                        }
                    }
                }

                if ((wire == "red" || wire == "left") && redCapacitors == 0)
                {
                    Console.WriteLine(blueCapacitors);
                    Console.WriteLine("disarmed");                    
                }

                else if ((wire == "blue" || wire == "right") && blueCapacitors == 0)
                {
                    Console.WriteLine(redCapacitors);
                    Console.WriteLine("disarmed");                    
                }

                else
                {
                    if (wire == "red" || wire == "left")
                    {
                        Console.WriteLine(redCapacitors);
                    }

                    else
                    {
                        Console.WriteLine(blueCapacitors);
                    }

                    Console.WriteLine("BOOM");                    
                }

                gameOver = true;

            }

            if (currentCommand == null)
            {
                gameOver = true; 
            }
        }
    }

    public static bool capacitorCheck(char[,] circuit, int row, int column)
    {
        if (
            row - 1 < 0 ||
            row + 1 > 15 ||
            column - 1 < 0 ||
            column + 1 > 15
            )
        {
            return false; 
        }

        else if (
                circuit[row, column] == '0' &&
                circuit[row - 1, column - 1] == '1' &&
                circuit[row - 1, column] == '1' &&
                circuit[row - 1, column + 1] == '1' &&
                circuit[row, column - 1] == '1' &&
                circuit[row, column + 1] == '1' &&
                circuit[row + 1, column - 1] == '1' &&
                circuit[row + 1, column] == '1' &&
                circuit[row + 1, column + 1] == '1'
            )
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
