using System;
using System.Text;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/266

class SevenlandNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();        

        int decimalNum = 0;

        for (int index = input.Length - 1, power = 0; index >= 0; index--, power++)
        {           
            int digit = input[index] - '0';

            decimalNum += (int)(digit * Math.Pow(7, power));
        }

        decimalNum++;

        StringBuilder result = new StringBuilder();

        while (decimalNum > 0)
        {
            char digit = (char)(decimalNum % 7 + '0');
            result.Insert(0, digit);
            decimalNum /= 7;
        }

        Console.WriteLine(result.ToString());
    }
}
