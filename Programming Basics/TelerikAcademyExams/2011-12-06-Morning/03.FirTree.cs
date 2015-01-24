using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/13

class FirTree
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());

        int dots = height - 2;
        int stars = 1;

        string firstRow = new string('.', dots) + "*" + new string('.', dots);

        for (int i = 0; i < height; i++)
        {
            if (i == 0 || i == height - 1)
            {
                Console.WriteLine(firstRow);
            }
            else
            {
                Console.WriteLine("{0}{1}{0}", new string('.', dots), new string('*', stars));
            }

            dots--;
            stars += 2;
        }
    }
}
