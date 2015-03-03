namespace _02.Decoding
{
    using System;

    public class Decoding
    {
        public static void Main()
        {
            int salt = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                char currentSymbol = text[i];

                if (currentSymbol == '@')
                {
                    break;
                }

                double result;

                if (char.IsLetter(currentSymbol))
                {
                    result = (currentSymbol * salt) + 1000;
                }
                else if (char.IsDigit(currentSymbol))
                {
                    result = currentSymbol + salt + 500;
                }
                else
                {
                    result = currentSymbol - salt;
                }

                if (i % 2 == 0)
                {
                    result /= 100;
                    Console.WriteLine("{0:F2}", result);
                }
                else
                {
                    result *= 100;
                    Console.WriteLine(result);
                }
            }
        }
    }
}
