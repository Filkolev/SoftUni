namespace _02.SymbolToNumber
{
    using System;

    public class SymbolToNumber
    {
        public static void Main()
        {
            int secret = int.Parse(Console.ReadLine());
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
                    result = (currentSymbol * secret) + 1000;
                }
                else if (char.IsDigit(currentSymbol))
                {
                    result = currentSymbol + secret + 500;
                }
                else
                {
                    result = currentSymbol - secret;
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
