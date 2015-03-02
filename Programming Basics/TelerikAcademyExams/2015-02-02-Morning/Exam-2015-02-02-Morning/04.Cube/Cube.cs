namespace _04.Cube
{
    using System;

    public class Cube
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            
            int topAndFrontFill = size - 2;
            int sideFill = 0;
            int outerSpace = size - 1;

            Console.WriteLine(
                "{0}{1}", 
                new string(' ', outerSpace), 
                new string(':', size));

            outerSpace--;

            for (int i = 0; i < size - 2; i++)
            {
                Console.WriteLine(
                    "{0}:{1}:{2}:", 
                    new string(' ', outerSpace), 
                    new string('/', topAndFrontFill), 
                    new string('X', sideFill));

                outerSpace--;
                sideFill++;
            }

            Console.WriteLine(
                "{0}{1}:", 
                new string(':', size), 
                new string('X', sideFill));

            sideFill--;

            for (int i = 0; i < size - 2; i++)
            {
                Console.WriteLine(
                    ":{0}:{1}:{2}", 
                    new string(' ', topAndFrontFill), 
                    new string('X', sideFill), 
                    new string(' ', outerSpace));

                outerSpace++;
                sideFill--;
            }

            Console.WriteLine(new string(':', size));
        }
    }
}
