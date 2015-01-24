using System;

class PandaScotlandFlag
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int outerTilde = 0;
        int innerSymbols = size - 2;
        char currentChar = 'A';

        for (int i = 0; i < size / 2; i++)
        {          

            Console.Write(new string('~', outerTilde));
            Console.Write(currentChar);
            currentChar =  ChangeChar(currentChar);
            Console.Write(new string('#', innerSymbols));
            Console.Write(currentChar);
            currentChar = ChangeChar(currentChar);
            Console.Write(new string('~', outerTilde));
            Console.WriteLine();

            innerSymbols -= 2;
            outerTilde++;
        }

        Console.WriteLine("{0}{1}{0}", new string('-', size / 2), currentChar);
        currentChar = ChangeChar(currentChar);

        outerTilde = (size - 3) / 2;
        innerSymbols = 1;

        for (int i = 0; i < size / 2; i++)
        {            

            Console.Write(new string('~', outerTilde));
            Console.Write(currentChar);
            currentChar = ChangeChar(currentChar);
            Console.Write(new string('#', innerSymbols));
            Console.Write(currentChar);
            currentChar = ChangeChar(currentChar);
            Console.Write(new string('~', outerTilde));
            Console.WriteLine();

            innerSymbols += 2;
            outerTilde--;
        }

    }

    static char ChangeChar(char currentChar)
    {
        char newChar = (char)(currentChar + 1);

        if (currentChar == 'Z')
        {
            newChar = 'A';
        }

        return newChar;
    }
}
