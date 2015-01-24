using System;

class Program
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());

        int lettersSum = 0;
        int symbolsSum = 0;
        int digitsSum = 0;

        for (int i = 0; i < count; i++)
        {
            string currentString = Console.ReadLine().ToLower();

            foreach (var ch in currentString)
            {
                if (ch == ' ' &&
                    ch != '\t' &&
                    ch != '\r' &&
                    ch != '\n')
                {
                    if (ch >= 'a' && ch <= 'z')
                    {
                        int weight = (ch - 'a' + 1) * 10;
                        lettersSum += weight;
                    }

                    else if (ch >= '0' && ch <= '9')
                    {
                        int weight = (ch - '0') * 20;
                        digitsSum += weight;
                    }

                    else
                    {
                        symbolsSum += 200;
                    }


                }
            }

        }

        Console.WriteLine(lettersSum);
        Console.WriteLine(digitsSum);
        Console.WriteLine(symbolsSum);
    }
}
