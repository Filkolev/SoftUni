using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/88

class ProgrammerDNA
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        char letter = Convert.ToChar(Console.ReadLine());

        for (int i = 0; i < size; i++)
        {
            int rowOfBlock = i % 7;

            if (rowOfBlock <= 3)
            {
                int outerDots = 3 - rowOfBlock;
                int numberOfChars = 1 + 2 * rowOfBlock;

                Console.Write(new string('.', outerDots));

                for (int j = 0; j < numberOfChars; j++)
                {
                    Console.Write(letter);
                    letter = ChangeLetter(letter);
                }

                Console.Write(new string('.', outerDots));
            }

            else
            {                
                int outerDots = rowOfBlock - 3;
                int numberOfChars = 0;

                switch (rowOfBlock)
                {
                    case 4: numberOfChars = 5; break;
                    case 5: numberOfChars = 3; break;
                    case 6: numberOfChars = 1; break;
                }

                Console.Write(new string('.', outerDots));

                for (int j = 0; j < numberOfChars; j++)
                {
                    Console.Write(letter);
                    letter = ChangeLetter(letter);
                }

                Console.Write(new string('.', outerDots));
            }

            Console.WriteLine();
        }     
    }

    static char ChangeLetter(char letter)
    {
        char newLetter = (char)(letter + 1);

        if (letter == 'G')
        {
            newLetter = 'A';
        }

        return newLetter;
    }
}
