namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        private static void Main()
        {
            string command = string.Empty;
            char[,] board = CreateBoard();
            char[,] bombs = PlaceBombs();
            int score = 0;
            bool exploded = false;
            List<Player> topScorers = new List<Player>(6);
            int row = 0;
            int column = 0;
            bool firstMove = true;
            const int Max = 35;
            bool gameWon = false;

            do
            {
                if (firstMove)
                {
                    Console.WriteLine("Let's play \"Game\". Try to find the cells without bombs in them."
                        + " Command 'top' shows the scoreboard, 'restart' starts a new game, 'exit' ends the game!");
                    DrawBoard(board);
                    firstMove = false;
                }

                Console.Write("Enter row and column: ");

                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column)
                        && row <= board.GetLength(0) && column <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintScore(topScorers);
                        break;
                    case "restart":
                        board = CreateBoard();
                        bombs = PlaceBombs();
                        DrawBoard(board);
                        break;
                    case "exit":
                        Console.WriteLine("Goodbye!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                Move(board, bombs, row, column);
                                score++;
                            }

                            if (Max == score)
                            {
                                gameWon = true;
                            }
                            else
                            {
                                DrawBoard(board);
                            }
                        }
                        else
                        {
                            exploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command!\n");
                        break;
                }

                if (exploded)
                {
                    DrawBoard(bombs);

                    Console.Write("\nOuch! You died heroically with {0} points. Enter your nickname: ", score);

                    string nickname = Console.ReadLine();
                    Player t = new Player(nickname, score);

                    if (topScorers.Count < 5)
                    {
                        topScorers.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < topScorers.Count; i++)
                        {
                            if (topScorers[i].Points < t.Points)
                            {
                                topScorers.Insert(i, t);
                                topScorers.RemoveAt(topScorers.Count - 1);
                                break;
                            }
                        }
                    }

                    topScorers.Sort((r1, r2) => r2.Name.CompareTo(r1.Name));
                    topScorers.Sort((r1, r2) => r2.Points.CompareTo(r1.Points));
                    PrintScore(topScorers);

                    board = CreateBoard();
                    bombs = PlaceBombs();
                    score = 0;
                    exploded = false;
                    firstMove = true;
                }

                if (gameWon)
                {
                    Console.WriteLine("\nCongratulations! You opened 35 cells without getting hurt!");
                    DrawBoard(bombs);
                    Console.WriteLine("Please enter your name: ");
                    string name = Console.ReadLine();
                    Player points = new Player(name, score);
                    topScorers.Add(points);
                    PrintScore(topScorers);
                    board = CreateBoard();
                    bombs = PlaceBombs();
                    score = 0;
                    gameWon = false;
                    firstMove = true;
                }
            } 
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria!");
            Console.Read();
        }

        private static void PrintScore(List<Player> players)
        {
            Console.WriteLine("\nPoints:");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, players[i].Name, players[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty scoreboard!\n");
            }
        }

        private static void Move(char[,] board, char[,] bombs, int row, int column)
        {
            char countOfBombs = CountBombs(bombs, row, column);
            bombs[row, column] = countOfBombs;
            board[row, column] = countOfBombs;
        }

        private static void DrawBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            Random random = new Random();

            int rows = 5;
            int columns = 10;
            char[,] board = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> bombs = new List<int>();

            while (bombs.Count < 15)
            {
                int coordinates = random.Next(50);
                if (!bombs.Contains(coordinates))
                {
                    bombs.Add(coordinates);
                }
            }

            foreach (int coordinate in bombs)
            {
                int column = coordinate / columns;
                int row = coordinate % columns;
                if (row == 0 && coordinate != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                board[column, row - 1] = '*';
            }

            return board;
        }

        private static char CountBombs(char[,] board, int row, int column)
        {
            int count = 0;
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, column] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (board[row + 1, column] == '*')
                {
                    count++;
                }
            }

            if (column - 1 >= 0)
            {
                if (board[row, column - 1] == '*')
                {
                    count++;
                }
            }

            if (column + 1 < columns)
            {
                if (board[row, column + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (board[row - 1, column - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (board[row - 1, column + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (board[row + 1, column - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (board[row + 1, column + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}