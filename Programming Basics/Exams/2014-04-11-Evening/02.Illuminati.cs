using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/45

class Illuminati
{
    static void Main()
    {
        string inputLine = Console.ReadLine().ToUpper();

        int countOfVowels = 0;
        int result = 0;

        for (int i = 0; i < inputLine.Length; i++)
        {
            switch (inputLine[i])
            {               
                case 'A': 
                    countOfVowels++;
                    result += 'A';
                    break;                
                case 'E':
                    countOfVowels++;
                    result += 'E';
                    break;               
                case 'I':
                    countOfVowels++;
                    result += 'I';
                    break;               
                case 'O':
                    countOfVowels++;
                    result += 'O';
                    break;               
                case 'U':
                    countOfVowels++;
                    result += 'U';
                    break;
            }
        }

        Console.WriteLine(countOfVowels);
        Console.WriteLine(result);
    }
}
