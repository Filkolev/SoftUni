namespace _02.TextToNumber
{
    using System;

    public class TextToNumber
    {
        public static void Main()
        {
            int moduloDivisor = int.Parse(Console.ReadLine());
            string text = Console.ReadLine().ToLower();

            long result = CalculateTextToNumberResult(text, moduloDivisor);

            Console.WriteLine(result);
        }

        private static long CalculateTextToNumberResult(string text, int moduloDivisor)
        {
            long result = 0;

            foreach (var symbol in text)
            {
                if (symbol == '@')
                {
                    break;
                }

                if (char.IsDigit(symbol))
                {
                    int digit = symbol - '0';
                    result *= digit;
                }
                else if (char.IsLetter(symbol))
                {
                    int positionOfLetter = symbol - 'a';
                    result += positionOfLetter;
                }
                else
                {
                    result %= moduloDivisor;
                }
            }

            return result;
        }
    }
}
