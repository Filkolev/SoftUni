using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/2

class MissCat2011
{
    static void Main()
    {
        int countOfJudges = int.Parse(Console.ReadLine());

        int[] scores = new int[10];

        for (int i = 0; i < countOfJudges; i++)
        {
            int vote = int.Parse(Console.ReadLine());
            scores[vote - 1]++;
        }

        int winner = 0;
        int maxScore = 0;

        for (int i = 0; i < 10; i++)
        {
            if (scores[i] > maxScore)
            {
                winner = i + 1;
                maxScore = scores[i];
            }
        }

        Console.WriteLine(winner);
    }
}
