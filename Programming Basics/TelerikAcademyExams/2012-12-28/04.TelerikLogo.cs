using System;

class TelerikLogo
{
    static void Main()
    {
        int X = int.Parse(Console.ReadLine());

        int width = 2 * X + X / 2 + X / 2 - 1;
        int height = 3 * X - 2;

        char[,] logo = new char[height, width];

        for (int row = 0; row < height; row++)
        {
            for (int column = 0; column < width; column++)
            {
                logo[row, column] = '.';
            }
        }

        int currentRow = X / 2;
        int currentCol = 0;

        while (currentRow >= 0)
        {
            logo[currentRow, currentCol] = '*';

            currentCol++;
            currentRow--;
        }

        currentRow += 2;        

        while (currentCol <= width - X / 2 - 1)
        {
            logo[currentRow, currentCol] = '*';

            currentRow++;
            currentCol++;
        }
       
        currentCol -= 2;

        while (currentRow < height)
        {
            logo[currentRow, currentCol] = '*';

            currentRow++;
            currentCol--;
        }

        currentRow -= 2;       

        while (currentCol >= X / 2)
        {
            logo[currentRow, currentCol] = '*';

            currentRow--;
            currentCol--;
        }

        currentCol += 2;    

        while (currentRow >= 0)
        {
            logo[currentRow, currentCol] = '*';

            currentRow--;
            currentCol++;
        }

        currentRow += 2;        

        while (currentCol < width)
        {
            logo[currentRow, currentCol] = '*';

            currentRow++;
            currentCol++;
        }


        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                Console.Write(logo[row, col]);
            }

            Console.WriteLine();
        }
    }
}
