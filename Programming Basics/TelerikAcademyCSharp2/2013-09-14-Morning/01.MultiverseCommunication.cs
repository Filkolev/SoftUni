using System;
using System.Collections.Generic;
using System.Text;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/454

class MultiverseCommunication
{
    static void Main()
    {
        Dictionary<string, string> code = new Dictionary<string, string>()
        {
            {"CHU", "0"},
            {"TEL", "1"},
            {"OFT", "2"},
            {"IVA", "3"},
            {"EMY", "4"},
            {"VNB", "5"},
            {"POQ", "6"},
            {"ERI", "7"},
            {"CAD", "8"},
            {"K-A", "9"},
            {"IIA", "A"},
            {"YLO", "B"},
            {"PLA", "C"},
        };

        StringBuilder decrypter = new StringBuilder();

        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i += 3)
        {
            string currentString = input.Substring(i, 3);
            string decrypted = "";
            code.TryGetValue(currentString, out decrypted);
            decrypter.Append(decrypted);
        }

        long result = 0;
        int power = 0;

        while (decrypter.Length > 0)
        {
            char currentDigit = decrypter[decrypter.Length - 1];           

            switch (currentDigit)
            {
                case 'A': result += 10 * (long)Math.Pow(13, power); break;
                case 'B': result += 11 * (long)Math.Pow(13, power); break;
                case 'C': result += 12 * (long)Math.Pow(13, power); break;
                default:  result += (currentDigit - '0') * (long)Math.Pow(13, power); break;
            }

            power++;
            decrypter.Remove(decrypter.Length - 1, 1);
        }

        Console.WriteLine(result);
    }
}
