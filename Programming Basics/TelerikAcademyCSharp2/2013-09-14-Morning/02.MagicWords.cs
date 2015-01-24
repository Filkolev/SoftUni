using System;
using System.Collections.Generic;
using System.Text;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/455

class MagicWords
{
    static void Main()
    {
        List<string> words = new List<string>();

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            words.Add(Console.ReadLine());
        }

        int indexToMoveTo = 0;        

        for (int i = 0; i < count; i++)
        {
            string currentWord = words[i];
            
            indexToMoveTo = (currentWord.Length % (count + 1));

            if (indexToMoveTo == count)
            {
                words.Add(currentWord);
            }
            else
            {
                words.Insert(indexToMoveTo, currentWord);
            }

            if (indexToMoveTo < i)
            {
                words.RemoveAt(i + 1);
            }
            else
            {
                words.RemoveAt(i);
            }         
        }

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < count; j++)
            {
                string currentWord = words[j];

                if (i < currentWord.Length)
                {
                    sb.Append(currentWord[i]);
                }
            }
        }

        Console.WriteLine(sb);

    }
}
