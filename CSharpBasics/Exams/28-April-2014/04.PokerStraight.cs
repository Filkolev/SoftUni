using System;
using System.Linq;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/106

class PokerStraight
{
    static void Main()
    {
        int w = int.Parse(Console.ReadLine());

        if (w > 2500)
        {
            Console.WriteLine(0);
            return;
        }

        int calculatedWeight = 0;
        int handsFound = 0;

        int[] faces = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
       
        for (int lowestCard = 0; lowestCard < 10; lowestCard++)
        {
            int[] currentHand = faces.Skip(lowestCard).Take(5).ToArray();

            for (int i = 1; i <= 5; i++)
            {
                calculatedWeight += i * 10 * currentHand[i - 1];
            } 

            int suitDifference = w - calculatedWeight;

            for (int i = 1; i < 5; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    for (int k = 1; k < 5; k++)
                    {
                        for (int l = 1; l < 5; l++)
                        {
                            for (int m = 1; m < 5; m++)
                            {
                                if (suitDifference == i + j + k + l + m)
                                {
                                    handsFound++;
                                }
                            }
                        }
                    }
                }
            }


            calculatedWeight = 0;
        }             

        Console.WriteLine(handsFound);
    }
}
