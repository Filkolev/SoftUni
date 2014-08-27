using System;

class TicTacPower
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int startingNumber = int.Parse(Console.ReadLine());

        int index = 1;

        switch (y)
        {
            case 1: index = 4;
                break;
            case 2: index = 7;
                break;
        }

        index += x;

        int value = startingNumber + index - 1;

        ulong result = (ulong)Math.Pow(value, index);

        Console.WriteLine(result);
    }
}
