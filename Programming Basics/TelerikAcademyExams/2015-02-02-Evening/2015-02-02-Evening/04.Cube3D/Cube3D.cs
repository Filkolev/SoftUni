namespace _04.Cube3D
{
    using System;

    public class Cube3D
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int frontAndBottomFill = size - 2;
            int sideFill = 0;
            int outerSpace = size - 1;

            Console.WriteLine(
                "{0}{1}",
                new string(':', size),
                new string(' ', outerSpace));

            outerSpace--;

            for (int i = 0; i < size - 2; i++)
            {
                Console.WriteLine(
                    ":{0}:{1}:{2}",
                    new string(' ', frontAndBottomFill),
                    new string('|', sideFill),
                    new string(' ', outerSpace));

                outerSpace--;
                sideFill++;
            }

            Console.WriteLine(
                "{0}{1}:",
                new string(':', size),
                new string('|', sideFill));

            sideFill--;
            outerSpace++;

            for (int i = 0; i < size - 2; i++)
            {
                Console.WriteLine(
                    "{0}:{1}:{2}:",
                    new string(' ', outerSpace),
                    new string('-', frontAndBottomFill),
                    new string('|', sideFill));

                outerSpace++;
                sideFill--;
            }

            Console.WriteLine(
                "{0}{1}", 
                new string(' ', outerSpace), 
                new string(':', size));
        }
    }
}
