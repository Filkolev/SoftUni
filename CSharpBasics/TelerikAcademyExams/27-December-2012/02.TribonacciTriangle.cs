using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/263

class TribonacciTriangle
{
    static void Main()
    {
        long tribo1 = long.Parse(Console.ReadLine());
        long tribo2 = long.Parse(Console.ReadLine());
        long tribo3 = long.Parse(Console.ReadLine());

        long triboN = 0;

        int numberOfRows = int.Parse(Console.ReadLine());

        for (int row = 1; row <= numberOfRows; row++)
        {
            for (int element = 0; element < row; element++)
            {
                Console.Write(GetTriboN(ref tribo1, ref tribo2, ref tribo3, ref triboN, row, element));

                if (element != row - 1)
                {
                    Console.Write(" ");
                }                
            }

            Console.WriteLine();
        }
    }

    static long GetTriboN(ref long tribo1, ref long tribo2, ref long tribo3, ref long triboN, int row, int element)
    {
        if (row == 1)
        {
            return tribo1;
        }

        else if (row == 2)
        {
            if (element == 0)
            {
                return tribo2;
            }

            else
	        {
                return tribo3;
	        }
        }

        else
        {
            triboN = tribo1 + tribo2 + tribo3;

            tribo1 = tribo2;
            tribo2 = tribo3;
            tribo3 = triboN;

            return triboN;
        }
    }    
}
