using System;

class MatrixOfPalindromes
{
    static void Main()
    {
        int rows;
        int columns;

        Console.Write("Enter the number of rows: ");
        while (!int.TryParse(Console.ReadLine(), out rows) || rows < 1)
        {
            Console.Write("Please enter an integer greater than 0: ");
        }

        Console.Write("Enter the number of columns: ");
        while (!int.TryParse(Console.ReadLine(), out columns) || rows < 1)
        {
            Console.Write("Please enter an integer greater than 0: ");
        }

        Console.WriteLine("\nResult:");
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Console.Write("{0}{1}{0} ", (char)('a' + row), (char)('a' + col + row));
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
