namespace _05.HorsePath
{
    using System;

    public class KnightPath
    {
        public static void Main()
        {
            int[] numbers = new int[8];

            int rowPosition = 0;
            int columnPosition = 0;

            numbers[0] = 1;

            string command = Console.ReadLine();

            while (command != "stop")
            {
                int nextRow = -1;
                int nextColumn = -1;

                string[] directionData = command.Split();

                switch (directionData[0])
                {
                    case "up":
                        nextRow = rowPosition - 2;
                        break;
                    case "down":
                        nextRow = rowPosition + 2;
                        break;
                    case "left":
                        nextColumn = columnPosition + 2;
                        break;
                    case "right":
                        nextColumn = columnPosition - 2;
                        break;
                }

                switch (directionData[1])
                {
                    case "up":
                        nextRow = rowPosition - 1;
                        break;
                    case "down":
                        nextRow = rowPosition + 1;
                        break;
                    case "left":
                        nextColumn = columnPosition + 1;
                        break;
                    case "right":
                        nextColumn = columnPosition - 1;
                        break;
                }

                if (0 <= nextRow && nextRow <= 7 && 0 <= nextColumn && nextColumn <= 7)
                {
                    rowPosition = nextRow;
                    columnPosition = nextColumn;

                    numbers[rowPosition] ^= (1 << columnPosition);
                }

                command = Console.ReadLine();
            }

            bool isZeroBoard = true;

            foreach (int number in numbers)
            {
                if (number != 0)
                {
                    Console.WriteLine(number);
                    isZeroBoard = false;
                }
            }

            if (isZeroBoard)
            {
                Console.WriteLine("[Board is empty]");
            }
        }
    }
}