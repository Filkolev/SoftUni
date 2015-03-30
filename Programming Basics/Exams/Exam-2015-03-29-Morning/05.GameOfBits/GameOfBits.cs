namespace _05.GameOfBits
{
    using System;

    public class GameOfBits
    {
        public static void Main()
        {
            long number = long.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "Game Over!")
            {
                int resultingNumber = 0;

                if (command == "Even")
                {
                    number >>= 1;
                }

                int index = 0;
                while (number > 0)
                {
                    resultingNumber |= (int)(number & 1) << index;
                    number >>= 2;
                    index++;
                }

                number = resultingNumber;
                command = Console.ReadLine();
            }

            int countOfBits = GetBitCount(number);

            Console.WriteLine("{0} -> {1}", number, countOfBits);
        }

        private static int GetBitCount(long number)
        {
            int count = 0;

            while (number > 0)
            {
                count += (int)(number & 1);
                number >>= 1;
            }

            return count;
        }
    }
}