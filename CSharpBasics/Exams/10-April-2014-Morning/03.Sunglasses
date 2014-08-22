using System;

// Find problem here: http://judge.softuni.bg/Contests/Practice/DownloadResource/16

class Sunglasses
{
    static void Main()
    {        
        int size = int.Parse(Console.ReadLine());

        string slash = new string('/', 2 * size-2);
        string verticalLines = new string('|', size);
        string emptySpace = new string(' ', size);
        string asterisk = new string('*', 2 * size);        

        for (int i = 1; i <= size; i++)
        {
            if ((i == 1) || (i == size))
            {
                Console.WriteLine("{0}{1}{0}", asterisk, emptySpace); // first and last line
            }

            else if (i == size / 2 + 1)
            {
                Console.WriteLine("*{0}*{1}*{0}*", slash, verticalLines); // middle line
            }

            else
            {
                Console.WriteLine("*{0}*{1}*{0}*",slash, emptySpace); // all other lines
            }
        }             
    }
}
