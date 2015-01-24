using System;
using System.Linq;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/173

class BitPaths
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int[] numbers = new int[8];

        for (int i = 0; i < N; i++)
        {
            string currentInput = Console.ReadLine();

            int[] currentPath = Array.ConvertAll(currentInput.Split(','), x => int.Parse(x));

            int currentPosition = 3 - currentPath[0];

            for (int j = 0; j < 8; j++)
            {
                int currentBit = (numbers[j] >> currentPosition) & 1;

                numbers[j] = numbers[j] ^ (1 << currentPosition);               

                if (j == 7)
                {
                    break;
                }

                currentPosition -= currentPath[j + 1]; 
            }
        }

        int sum = numbers.Sum();

        Console.WriteLine(Convert.ToString(sum, 2));
        Console.WriteLine(Convert.ToString(sum, 16).ToUpper());
    }
}
