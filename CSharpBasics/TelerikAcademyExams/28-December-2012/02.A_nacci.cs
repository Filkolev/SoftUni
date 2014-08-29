using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/267

class A_nacci
{
    static void Main()
    {
        char ch1 = Console.ReadLine()[0];
        char ch2 = Console.ReadLine()[0];

        int rows = int.Parse(Console.ReadLine());

        Console.WriteLine(ch1);

        for (int i = 1; i <= rows - 1; i++)
        {
            int whitespaces = i - 1;

            GetCurrentChars(ref ch1, ref ch2, i);

            Console.WriteLine("{0}{1}{2}", ch1, new string(' ', whitespaces), ch2);
        }
    }

    static void GetCurrentChars(ref char ch1, ref char ch2, int row)
    {
        int index1 = ch1 - 'A' + 1;
        int index2 = ch2 - 'A' + 1;

        int nextIndex = index1 + index2;
        if (nextIndex > 26)
        {
            nextIndex -= 26;
        }

        if (row > 1)
        {
            index1 = index2;
            index2 = nextIndex;
            nextIndex = index1 + index2;
            if (nextIndex > 26)
            {
                nextIndex -= 26;
            }
        }

        ch1 = (char)(index2 + 'A' - 1);
        ch2 = (char)(nextIndex + 'A' - 1);
    }
}
