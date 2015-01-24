using System;

class BitPathsStrings
{
    static void Main()
    {
        byte count = byte.Parse(Console.ReadLine());

        char[][] board = new char[8][];

        for (byte row = 0; row < 8; row++)
        {
            board[row] = new char[] {'0', '0', '0', '0'};           
        }


        for (byte i = 0; i < count; i++)
        {
            sbyte[] path = new sbyte[8];

            string[] input = Console.ReadLine().Split(',');

            for (byte num = 0; num < 8; num++)
            {
                path[num] = sbyte.Parse(input[num]);
            }

            sbyte position = 0;

            for (byte row = 0; row < 8; row++)
            {
                position += path[row];

                if (board[row][position] == '0')
                {
                    board[row][position] = '1';
                }
                else
                {
                    board[row][position] = '0';
                }
            }
        }

        byte sum = 0;

        for (byte i = 0; i < 8; i++)
        {
            sum += Convert.ToByte(new string(board[i]), 2);
        }

        Console.WriteLine(Convert.ToString(sum, 2));
        Console.WriteLine("{0:X}", sum);
    }
}
