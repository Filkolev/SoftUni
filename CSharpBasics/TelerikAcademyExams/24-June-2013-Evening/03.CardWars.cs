using System;
using System.Numerics;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/451

class CardWars
{
    static void Main()
    {
        int numberOfGames = int.Parse(Console.ReadLine());

        int firstPlayerGamesWon = 0;
        BigInteger firstPlayerScore = 0;

        int secondPlayerGamesWon = 0;
        BigInteger secondPlayerScore = 0;

        for (int i = 0; i < numberOfGames; i++)
        {
            int firstPlayerHandStrength = 0;
            int secondPlayerHandStrength = 0;

            bool firstPlayerWins = false;
            bool secondPlayerWins = false;

            string[] firstPlayerHand = new string[3];
            string[] secondPlayerHand = new string[3];

            for (int card = 0; card < 3; card++)
            {
                firstPlayerHand[card] = Console.ReadLine();
            }

            for (int card = 0; card < 3; card++)
            {
                secondPlayerHand[card] = Console.ReadLine();
            }          

            for (int cardIndex = 0; cardIndex < 3; cardIndex++)
            {
                GetCurrentHandStrength(firstPlayerHand[cardIndex], ref firstPlayerHandStrength, ref firstPlayerScore, ref firstPlayerWins);
                GetCurrentHandStrength(secondPlayerHand[cardIndex], ref secondPlayerHandStrength, ref secondPlayerScore, ref secondPlayerWins);
            }

            if (firstPlayerWins && secondPlayerWins)
            {
                firstPlayerScore += 50;
                secondPlayerScore += 50;
            }
            else if (firstPlayerWins && !secondPlayerWins)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
                return;
            }
            else if (!firstPlayerWins && secondPlayerWins)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
                return;
            }

            if (firstPlayerHandStrength > secondPlayerHandStrength)
            {
                firstPlayerGamesWon++;
                firstPlayerScore += firstPlayerHandStrength;
            }
            else if (firstPlayerHandStrength < secondPlayerHandStrength)
            {
                secondPlayerGamesWon++;
                secondPlayerScore += secondPlayerHandStrength;
            }
        }

        if (firstPlayerScore > secondPlayerScore)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", firstPlayerScore);
            Console.WriteLine("Games won: {0}", firstPlayerGamesWon);
        }
        else if (firstPlayerScore < secondPlayerScore)
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", secondPlayerScore);
            Console.WriteLine("Games won: {0}", secondPlayerGamesWon);
        }
        else
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", secondPlayerScore);
        }
    }

    static void GetCurrentHandStrength (string card, ref int playerHandStrength, ref BigInteger playerScore, ref bool playerWins)
    {
        switch (card)
        {
            case "2": playerHandStrength += 10; break;
            case "3": playerHandStrength += 9; break;
            case "4": playerHandStrength += 8; break;
            case "5": playerHandStrength += 7; break;
            case "6": playerHandStrength += 6; break;
            case "7": playerHandStrength += 5; break;
            case "8": playerHandStrength += 4; break;
            case "9": playerHandStrength += 3; break;
            case "10": playerHandStrength += 2; break;
            case "A": playerHandStrength += 1; break;
            case "J": playerHandStrength += 11; break;
            case "Q": playerHandStrength += 12; break;
            case "K": playerHandStrength += 13; break;
            case "Z": playerScore *= 2; break;
            case "Y": playerScore -= 200; break;
            case "X": playerWins = true; break;
        }
    }
}
