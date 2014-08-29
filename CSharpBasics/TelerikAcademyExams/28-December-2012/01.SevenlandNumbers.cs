using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/266

class SevenlandNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();        

        string result = "";
        int trailingZeros = 0;
        
        for (int index = input.Length - 1; index >= 0; index--)
        {
            char digit = input[index];           

            if (digit == '6')
            {
                trailingZeros++;
            }

            else
            {
                result = input.Substring(0, index) + (char)(digit + 1) + new string('0', trailingZeros);
                break;
            }
        }

        if (trailingZeros == input.Length)
        {
            result = "1" + new string('0', trailingZeros);
        }

        Console.WriteLine(result);
    }
}
