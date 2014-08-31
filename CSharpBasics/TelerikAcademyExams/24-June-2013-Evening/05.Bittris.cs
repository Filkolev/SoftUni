using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/453

class Bittris
{
    static void Main()
    {
        uint numberOfCommands = uint.Parse(Console.ReadLine());
        uint pieces = numberOfCommands / 4;

        long score = 0;

        byte[] board = new byte[4];

        for (int i = 0; i < pieces; i++)
        {          
            uint currentPiece = uint.Parse(Console.ReadLine());

            bool blocked = false;
            int landRow = 3;          

            int pieceScore = 0;
            uint temp = currentPiece;
            while (temp > 0)
            {
                int bit = (int)(temp & 1);
                pieceScore += bit;
                temp >>= 1;
            }

            byte piece = (byte)currentPiece;

            if (board[0] > 0)
            {
                blocked = true;
                piece = 0;
            }

            for (int command = 0; command < 3; command++)
            {
                string currentCommand = Console.ReadLine();

                if (blocked)
                {
                    continue;
                }       
                
                if (currentCommand == "R")
                {
                    if ((piece & 1) == 0 && ((piece >> 1) & board[command]) == 0)
                    {
                        piece >>= 1;
                    }                    
                }
                else if (currentCommand == "L")
                {
                    if ((piece >> 7) == 0 && ((piece << 1) & board[command]) == 0)
                    {
                        piece <<= 1;
                    }                    
                }

                GoDown(board, ref blocked, piece, command, ref landRow);
            }

            board[landRow] |= piece;

            for (int j = 3; j >= 0; j--)
            {
                if (board[j] == 255)
                {
                    pieceScore *= 10;
                    board[j] = 0;

                    for (int k = j - 1; k >= 0; k--)
                    {
                        board[k + 1] = board[k];
                    }

                    board[0] = 0;
                    break;
                }
            }

            score += pieceScore;
        }

        Console.WriteLine(score);
    }

    private static void GoDown(byte[] board, ref bool blocked, byte piece, int command, ref int landRow)
    {
        if ((board[command + 1] & piece) != 0)
        {
            blocked = true;
            
            landRow = command;
        }        
    }
}
