namespace Exam_2015_03_29_Evening
{
    using System;

    public class MagicWand
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int width = 3 * size + 2;

            int outerDots = width / 2;
            int innerDots = 1;

            Console.WriteLine("{0}*{0}", new string('.', outerDots));
            outerDots--;

            for (int i = 0; i < size / 2 + 1; i++)
            {
                Console.WriteLine(
                    "{0}*{1}*{0}",
                    new string('.', outerDots),
                    new string('.', innerDots));

                outerDots--;
                innerDots += 2;
            }

            Console.WriteLine(
                "{0}*{1}*{0}",
                new string('*', outerDots),
                new string('.', innerDots));

            outerDots = 1;
            innerDots = width - 4;

            for (int i = 0; i < size / 2; i++)
            {
                Console.WriteLine(
                    "{0}*{1}*{0}",
                    new string('.', outerDots),
                    new string('.', innerDots));

                outerDots++;
                innerDots -= 2;
            }

            outerDots = size / 2 - 1;
            int middleDots = 0;

            for (int i = 0; i < size / 2; i++)
            {
                Console.WriteLine(
                    "{0}*{1}*{2}*{3}*{2}*{1}*{0}",
                    new string('.', outerDots),
                    new string('.', size / 2),
                    new string('.', middleDots),
                    new string('.', size));

                outerDots--;
                middleDots++;
            }

            Console.WriteLine(
                "{0}{1}*{2}*{1}{0}",
                new string('*', size / 2 + 1),
                new string('.', size / 2),
                new string('.', size));


            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("{0}*{0}*{0}", new string('.', size));
            }

            Console.WriteLine(
                "{0}*{1}*{0}",
                new string('.', size),
                new string('*', size));
        }
    }
}
