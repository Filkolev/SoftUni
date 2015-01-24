using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/181

class NakovsMatching
{
    static void Main()
    {
        string firstString = Console.ReadLine();
        string secondString = Console.ReadLine();

        int limit = int.Parse(Console.ReadLine());

        bool found = false;

        for (int i = 1; i < firstString.Length; i++)
        {            
            for (int j = 1; j < secondString.Length; j++)
            {
                string firstSubstring = firstString.Substring(0, i);
                string secondSubstring = firstString.Substring(i);                
                string thirdSubstring = secondString.Substring(0, j);
                string fourthSubstring = secondString.Substring(j);

                int weight = calculateWeight(firstSubstring) * calculateWeight(fourthSubstring) - calculateWeight(secondSubstring) * calculateWeight(thirdSubstring);

                if (Math.Abs(weight) <= limit)
                {
                    found = true;
                    Console.WriteLine("({0}|{1}) matches ({2}|{3}) by {4} nakovs", firstSubstring, secondSubstring, thirdSubstring, fourthSubstring, Math.Abs(weight));
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("No"); 
        }
    }

    public static int calculateWeight(string substring)
    {
        int weight = 0;

        for (int i = 0; i < substring.Length; i++)
        {
            weight += substring[i];
        }

        return weight;
    }
}
