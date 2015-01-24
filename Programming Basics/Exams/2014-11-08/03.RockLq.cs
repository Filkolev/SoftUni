using System;

class RockLq
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int outerDots = size;
        int innerDots = size - 2;

        for (int i = 0; i < size / 2 + 1; i++)
        {
            if (i == 0)
            {
                Console.WriteLine("{0}*{1}*{0}", new string('.', outerDots), new string('*', innerDots));
            }
            else
            {
                Console.WriteLine("{0}*{1}*{0}", new string('.', outerDots), new string('.', innerDots));
            }

            outerDots -= 2;
            innerDots += 4;
        }


        Console.WriteLine("*{0}*{1}*{0}*", new string('.', size - 2), new string('.', size));

        outerDots = size - 4;
        int middleDots = 1;
        innerDots = size;

        for (int i = 0; i < size / 2 - 1; i++)
        {
          
            Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*", new string('.', outerDots), new string('.', middleDots), new string('.', innerDots));
            outerDots -= 2;
            middleDots += 2;
        }

        outerDots = size - 1;
        

        for (int i = 0; i < size; i++)
        {
            if (i == size - 1)
            {
                Console.WriteLine("{0}*{1}*{0}", new string('.', outerDots), new string('*', innerDots));
            }
            else
            {
                Console.WriteLine("{0}*{1}*{0}", new string('.', outerDots), new string('.', innerDots));
            }

            outerDots--;
            innerDots += 2;
        }
    }
}
