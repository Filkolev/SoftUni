using System;

class BitBuilder
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        string input = Console.ReadLine();

        while (input != "quit")
        {
            int position = int.Parse(input);
            string command = Console.ReadLine();
            long one = 1L;

            if (command == "flip")
            {
                number ^= (1 << position);
            }
            else if (command == "insert")
            {
                long left = number >> position;
                long rightMask = (1 << position) - 1;
                long right = number & rightMask;
                number = (left << (position + 1)) | (one << position);
                number |= right;
            }
            else if (command == "remove")
            {
                long left = number >> (position + 1);
                long rightMask = (1 << position) - 1;
                long right = number & rightMask;
                number = (left << position) | right;
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(number);
    }
}
