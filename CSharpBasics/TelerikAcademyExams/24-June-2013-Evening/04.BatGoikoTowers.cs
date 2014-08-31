using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/452

class BatGoikoTowers
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int outerDots = size - 1;
        int innerSymbols = 0;
        int dotRowsToPrint = 0;
        int dotRowsPrinted = 0;
        bool beam = false;

        for (int i = 0; i < size; i++)
        {
            char innerSymbol = '.';

            if (beam)
            {
                innerSymbol = '-';
                beam = !beam;
            }

            Console.WriteLine("{0}/{1}\\{0}", new string('.', outerDots), new string(innerSymbol, innerSymbols));

            if (dotRowsToPrint != 0 && innerSymbol == '.')
            {
                dotRowsPrinted++;
            }

            if (dotRowsPrinted == dotRowsToPrint)
            {
                dotRowsToPrint++;
                dotRowsPrinted = 0;
                beam = true;
            }

            outerDots--;
            innerSymbols += 2;
        }
    }
}
