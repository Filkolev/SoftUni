using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/22

class AstrologicalDigits
{
    static void Main()
    {
        string input = Console.ReadLine().Replace("-", "").Replace(".", "");        

        while (input.Length > 1)
        {
            int result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                result += input[i] - '0';
            }

            input = result.ToString();
        }

        Console.WriteLine(input);
    }
}
