using System;

// Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) 
// and prints a matrix holding the numbers from 1 to n*n in the form of square spiral 

class SpiralMatrix
{
    static void Main()
    {
        Console.Write("Enter the size (width and height) of the spiral matrix.\nSize = ");
        int size = 0;

        while (!int.TryParse(Console.ReadLine(), out size) || size < 1 || size > 20)
        {
            Console.Write("\nThe size should be an integer number between 1 and 20 inclusive. Please re-enter.\nSize = ");
        }

        int[,] matrix = new int[size, size];

        int row = 0;
        int col = 0;

        string direction = "right";

        for (int num = 1; num <= size * size; num++)
        {
            if (direction == "right")
            {
                if (col < size && matrix[row, col] == 0)
                {
                    matrix[row, col] = num;
                    col++;
                }

                else
                {
                    direction = "down";
                    col--;
                    row++;
                }                
            }

            if (direction == "down")
            {
                if (row < size && matrix[row, col] == 0)
                {
                    matrix[row, col] = num;
                    row++;
                }

                else
                {
                    direction = "left";
                    row--;
                    col--;
                }
            }

            if (direction == "left")
            {
                if (col >= 0 && matrix[row, col] == 0)
                {
                    matrix[row, col] = num;
                    col--;
                }

                else
                {
                    direction = "up";
                    col++;
                    row--;
                }
            }

            if (direction == "up")
            {
                if (row >= 0 && matrix[row, col] == 0)
                {
                    matrix[row, col] = num;
                    row--;
                }

                else
                {
                    direction = "right";
                    row++;
                    col++;
                    num--;
                }
            }            
        }

        PrintMatrix(matrix);
    }

    static void PrintMatrix(int[,] matrix)
    {

        Console.WriteLine("\nResult:\n");
        if (matrix.Length < 10)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0, 2}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        else if (matrix.Length < 100)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0, 3}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        else
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0, 4}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        Console.WriteLine();
    }
}
