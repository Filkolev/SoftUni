namespace _04.PersianRugs
{
    using System;

    public class PersianRugs
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());

            int outerSymbols = 0;
            int innerSpaces = (size * 2) - 1;
            int innerDots = innerSpaces - (2 * distance) - 2;

            for (int i = 0; i < size; i++)
            {
                if (innerDots > 0)
                {
                    Console.WriteLine(
                    "{0}\\{1}\\{2}/{1}/{0}",
                    new string('#', outerSymbols),
                    new string(' ', distance),
                    new string('.', innerDots));
                }
                else
                {
                    Console.WriteLine(
                    "{0}\\{1}/{0}",
                    new string('#', outerSymbols),
                    new string(' ', innerSpaces));
                }

                outerSymbols++;
                innerSpaces -= 2;
                innerDots -= 2;
            }

            Console.WriteLine("{0}X{0}", new string('#', size));

            for (int i = 0; i < size; i++)
            {
                outerSymbols--;
                innerSpaces += 2;
                innerDots += 2;

                if (innerDots > 0)
                {
                    Console.WriteLine(
                     "{0}/{1}/{2}\\{1}\\{0}",
                     new string('#', outerSymbols),
                     new string(' ', distance),
                     new string('.', innerDots));
                }
                else
                {
                    Console.WriteLine(
                    "{0}/{1}\\{0}",
                    new string('#', outerSymbols),
                    new string(' ', innerSpaces));
                }
            }
        }
    }
}
