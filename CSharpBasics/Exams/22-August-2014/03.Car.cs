using System;

class Car
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int outerSymbols = size;
        int innerSymbols = size - 2;

        Console.WriteLine("{0}*{1}*{0}", new string('.', outerSymbols), new string('*', innerSymbols));

        for (int i = 0; i < size / 2 - 1; i++)
        {
            innerSymbols += 2;
            outerSymbols--;

            Console.WriteLine("{0}*{1}*{0}", new string('.', outerSymbols), new string('.', innerSymbols));
        }

        innerSymbols += 2;
        outerSymbols--;

        Console.WriteLine("{0}*{1}*{0}", new string('*', outerSymbols), new string('.', innerSymbols));

        for (int i = 0; i < size / 2 - 2; i++)
        {
            Console.WriteLine("*{0}*", new string('.', size * 3 - 2));
        }

        Console.WriteLine(new string('*', 3 * size));

        outerSymbols = size / 2;        
        int wheelWidth = (2 * size - 4) / 4;
        innerSymbols = wheelWidth * 2; ;

        for (int i = 0; i < size / 2 - 2; i++)
        {
            Console.WriteLine("{0}*{1}*{2}*{1}*{0}", new string('.', outerSymbols), new string('.', wheelWidth), new string('.', innerSymbols));
        }

        Console.WriteLine("{0}*{1}*{2}*{1}*{0}", new string('.', outerSymbols), new string('*', wheelWidth), new string('.', innerSymbols));
    }
}
