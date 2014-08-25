using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/177

class OddAndEvenJumps
{
    static void Main()
    {
        string input = Console.ReadLine();
        input = input.Replace(" ", string.Empty).ToLower();

        int oddJump = int.Parse(Console.ReadLine());
        int evenJump = int.Parse(Console.ReadLine());

        long odd = 0;
        long even = 0;

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (i % 2 == 0) // odd positions according to problem's description
            {
                if ((i / 2 + 1) % oddJump == 0|| oddJump == 1)
                {
                    odd *= currentChar;
                }

                else
                {
                    odd += currentChar;
                }
            }

            else
            {
                if ((i / 2 + 1) % evenJump == 0 || evenJump == 1)
                {
                    even *= currentChar;
                }

                else
                {
                    even += currentChar;
                }
            }
        }        

            Console.WriteLine("Odd: {0:X}", odd);
            Console.WriteLine("Even: {0:X}", even);
    }    
}
