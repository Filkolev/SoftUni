namespace _03.Dumbbell
{
    using System;

    public class Dumbbell
    {
        public static void Main()
        {
            int height = int.Parse(Console.ReadLine());

            int outerDots = height / 2;
            int innerSymbols = height - outerDots - 2;

            for (int i = 0; i < height; i++)
            {
                if (i == 0 || i == height - 1)
                {
                    Console.WriteLine(
                        "{0}&{1}&{2}&{1}&{0}",
                        new string('.', outerDots),
                        new string('&', innerSymbols),
                        new string('.', height));
                }
                else if (i == height / 2)
                {
                    Console.WriteLine(
                        "{0}&{1}&{2}&{1}&{0}",
                        new string('.', outerDots),
                        new string('*', innerSymbols),
                        new string('=', height));
                }
                else
                {
                    Console.WriteLine(
                        "{0}&{1}&{2}&{1}&{0}",
                        new string('.', outerDots),
                        new string('*', innerSymbols),
                        new string('.', height));
                }

                if (i < height / 2)
                {
                    outerDots--;
                    innerSymbols++;
                }
                else
                {
                    outerDots++;
                    innerSymbols--;
                }
            }
        }
    }
}
