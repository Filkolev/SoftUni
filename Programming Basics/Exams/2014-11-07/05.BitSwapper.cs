using System;

class BitSwapper
{
    static void Main()
    {
        long[] numbers = new long[4];

        for (int i = 0; i < 4; i++)
        {
            numbers[i] = long.Parse(Console.ReadLine());
        }

        string command = Console.ReadLine();

        while (command != "End")
        {
            string[] firstSequence = command.Split();
            int firstNumberIndex = int.Parse(firstSequence[0]);
            int firstNumberPosition = int.Parse(firstSequence[1]) * 4;

            string[] secondSequence = Console.ReadLine().Split();
            int secondNumIndex = int.Parse(secondSequence[0]);
            int secondNumPosition = int.Parse(secondSequence[1]) * 4;

            int mask = 15;

            long firstBits = (numbers[firstNumberIndex] >> firstNumberPosition) & mask;
            long secondBits = (numbers[secondNumIndex] >> secondNumPosition) & mask;

            numbers[firstNumberIndex] &= ~(mask << firstNumberPosition);
            numbers[firstNumberIndex] |= (secondBits << firstNumberPosition);

            numbers[secondNumIndex] &= ~(mask << secondNumPosition);
            numbers[secondNumIndex] |= (firstBits << secondNumPosition);

            command = Console.ReadLine();
        }

        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }
    }
}
