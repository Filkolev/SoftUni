using System;

class DoubleDowns
{
    static void Main()
    {
        int countOfNumbers = int.Parse(Console.ReadLine());

        int[] numbers = new int[countOfNumbers];

        for (int i = 0; i < countOfNumbers; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int rightDiagonal = 0;
        int vertical = 0;
        int leftDiagonal = 0;

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int topNum = numbers[i];
            for (int position = 0; position < 32; position++)
            {
                int topBit = (topNum >> position) & 1;

                if (topBit == 1)
                {
                    int bottomNum = numbers[i + 1];
                    int rightBit = (bottomNum >> position - 1) & 1;
                    int verticalBit = (bottomNum >> position) & 1;
                    int leftBit = (bottomNum >> position + 1) & 1;

                    if (rightBit == 1)
                    {
                        rightDiagonal++;
                    }

                    if (verticalBit == 1)
                    {
                        vertical++;                        
                    }

                    if (leftBit == 1)
                    {
                        leftDiagonal++;
                    }
                }
            }
        }

        Console.WriteLine(rightDiagonal);
        Console.WriteLine(leftDiagonal);
        Console.WriteLine(vertical);
    }
}
