using System;

class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int outerTilde = 0;
        int innerSymbols = size - 2;
        char letter = 'A';

        // upper part
        for (int i = 0; i < size / 2; i++)
        {
            Console.Write(new string('~', outerTilde));
            Console.Write(letter);
            ChangeLetter(ref letter);
            Console.Write(new string('#', innerSymbols));
            Console.Write(letter);
            ChangeLetter(ref letter);
            Console.Write(new string('~', outerTilde));
            Console.WriteLine();
            outerTilde++;
            innerSymbols -= 2;
        }

        Console.WriteLine(new string('-', size / 2) + letter + new string('-', size / 2));
        ChangeLetter(ref letter);

        outerTilde--;
        innerSymbols += 2;

        // lower part
        for (int i = 0; i < size / 2; i++)
        {
            Console.Write(new string('~', outerTilde));
            Console.Write(letter);
            ChangeLetter(ref letter);
            Console.Write(new string('#', innerSymbols));
            Console.Write(letter);
            ChangeLetter(ref letter);
            Console.Write(new string('~', outerTilde));
            Console.WriteLine();

            outerTilde--;
            innerSymbols += 2;
        }
    }

    static void ChangeLetter(ref char letter)
    {
        letter++;

        if (letter > 'Z')
        {
            letter = 'A';
        }        
    }
}
