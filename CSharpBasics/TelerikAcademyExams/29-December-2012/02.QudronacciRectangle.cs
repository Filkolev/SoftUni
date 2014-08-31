using System;
using System.Collections.Generic;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/271

class QudronacciRectangle
{
    static void Main()
    {
        long quadro1 = long.Parse(Console.ReadLine());
        long quadro2 = long.Parse(Console.ReadLine());
        long quadro3 = long.Parse(Console.ReadLine());
        long quadro4 = long.Parse(Console.ReadLine());

        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        int numberOfElements = rows * cols;

        List<long> quadronacciSequence = new List<long>();

        quadronacciSequence.Add(quadro1);
        quadronacciSequence.Add(quadro2);
        quadronacciSequence.Add(quadro3);
        quadronacciSequence.Add(quadro4);

        for (int i = 4; i < numberOfElements; i++)
        {
            long quadroN = quadro1 + quadro2 + quadro3 + quadro4;
            quadronacciSequence.Add(quadroN);
            quadro1 = quadro2;
            quadro2 = quadro3;
            quadro3 = quadro4;
            quadro4 = quadroN;
        }

        for (int i = 0; i < quadronacciSequence.Count; i++)
        {
            Console.Write(quadronacciSequence[i]);
            if (i % cols == cols - 1)
            {
                Console.WriteLine();
            }
            else
            {
                Console.Write(" ");
            }
        }
    }
}
