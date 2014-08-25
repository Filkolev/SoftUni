using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/167

class Letters_Symbols_Numbers
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int sumOfLetters = 0;
        int sumOfNumbers = 0;
        int sumOfSymbols = 0;

        for (int i = 0; i < N; i++)
        {
            string currentString = Console.ReadLine().ToUpper();
            for (int j = 0; j < currentString.Length; j++)
            {
                char currentChar = currentString[j];                

                if (currentChar == ' ' || currentChar == '\t' || currentChar == '\r' || currentChar == '\n')
                {
                    continue;
                }

                else if (currentChar >= 'A' && currentChar <= 'Z')
                {
                    sumOfLetters += (currentChar - 'A' + 1) * 10;
                }

                else if (currentChar >= '0' && currentChar <= '9')
                {
                    sumOfNumbers += (currentChar - '0') * 20;
                }

                else
                {
                    sumOfSymbols += 200;
                }
            }
        }

        Console.WriteLine(sumOfLetters);
        Console.WriteLine(sumOfNumbers);
        Console.WriteLine(sumOfSymbols);       
    }
}
