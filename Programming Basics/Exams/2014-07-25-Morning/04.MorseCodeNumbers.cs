using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/171

class MorseCodeNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();

        int digitSum = 0;

        for (int i = 0; i < 4; i++)
        {
            digitSum += (input[i] - '0');
        }

        string[] morseCode = { ".----|", "..---|", "...--|", "....-|", ".....|" };

        bool resultsFound = false;

        for (int i1 = 1; i1 <= 5; i1++)
        {
            for (int i2 = 1; i2 <= 5; i2++)
            {
                for (int i3 = 1; i3 <= 5; i3++)
                {
                    for (int i4 = 1; i4 <= 5; i4++)
                    {
                        for (int i5 = 1; i5 <= 5; i5++)
                        {
                            for (int i6 = 1; i6 <= 5; i6++)
                            {
                                int product = i1 * i2 * i3 * i4 * i5 * i6;

                                if (product == digitSum)
                                {
                                    Console.WriteLine("{0}{1}{2}{3}{4}{5}", morseCode[i1 - 1], morseCode[i2 - 1], morseCode[i3 - 1], morseCode[i4 - 1], morseCode[i5 - 1], morseCode[i6 - 1]);

                                    resultsFound = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        if (!resultsFound)
        {
            Console.WriteLine("No");
        }
    }
}
