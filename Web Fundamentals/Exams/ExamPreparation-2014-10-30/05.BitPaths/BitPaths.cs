using System;
using System.Linq;

class BitPaths
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        int[] board = new int[8];

        for (int i = 0; i < count; i++)
        {
            string input = Console.ReadLine();
            //int[] path = input.Split(',').Select(int.Parse).ToArray();
            //int[] path = Array.ConvertAll(input.Split(','), element => int.Parse(element));
            
            string[] currentPath = input.Split(',');
            int[] path = new int[8];

            for (int j = 0; j < 8; j++)
            {
                path[j] = int.Parse(currentPath[j]);
            }

            int position = 3 - path[0];

            for (int k = 0; k < 8; k++)
            {                
                int mask = (1 << position);
                board[k] = board[k] ^ mask;                

                if (k == 7)
                {
                    break;
                }

                position = position - path[k+1];
            }
        }

        int sum = board.Sum();
        Console.WriteLine(Convert.ToString(sum, 8));
        Console.WriteLine("{0:X}", sum);
    }   
}
