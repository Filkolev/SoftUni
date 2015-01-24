using System;

class Star
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int outerDots = size;
        int innerDots = 1;
        Console.WriteLine("{0}*{0}", new string('.', outerDots));

        for (int i = 0; i < size / 2 - 1; i++)
        {
            outerDots--;           

            Console.WriteLine("{0}*{1}*{0}", new string('.', outerDots), new string('.', innerDots));
            innerDots += 2;
        }

        outerDots--;       

        Console.WriteLine("{0}*{1}*{0}", new string('*', outerDots), new string('.', innerDots));

        outerDots = 1;
        innerDots = 2 * size - 3;

        for (int i = 0; i < size/2 - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', outerDots), new string('.', innerDots));

            outerDots++;
            innerDots -= 2;
        }

        int betweenTireDots = (innerDots - 1) / 2;

        Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', outerDots), new string('.', betweenTireDots));

        innerDots = 1;

        for (int i = 0; i < size/2 - 1; i++)
        {
            outerDots--;
            Console.WriteLine("{0}*{1}*{2}*{1}*{0}", new string('.', outerDots), new string('.', betweenTireDots), new string('.', innerDots));
            innerDots += 2;
        }
        outerDots--;

        Console.WriteLine("{0}*{1}*{2}*{1}*{0}", new string('.', outerDots), new string('*', betweenTireDots), new string('.', innerDots));
    }
}
