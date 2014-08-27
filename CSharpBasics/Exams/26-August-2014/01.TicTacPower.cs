using System;

class TicTacPower
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int startingNumber = int.Parse(Console.ReadLine());

        int index = 3 * y + x + 1; // Stole the formula ;)

        int value = startingNumber + index - 1;

        ulong result = (ulong)Math.Pow(value, index);

        Console.WriteLine(result);
    }
}
