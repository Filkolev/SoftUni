using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/277

class Poker
{
    static void Main()
    {       
        string[] hand = new string[5];
        string[] backup = new string[5];

        for (int i = 0; i < 5; i++)
        {
            hand[i] = Console.ReadLine();
            backup[i] = hand[i];
        }

        int[] sequences = new int[5];

        for (int i = 0; i < 5; i++)
        {
            if (hand[i] != "*")
            {
                sequences[i]++;

                string currentCard = hand[i];

                for (int j = i + 1; j < 5; j++)
                {
                    if (currentCard == hand[j])
                    {
                        sequences[i]++;
                        hand[j] = "*";
                    }
                }
            }
        }

        Array.Sort(sequences);
        Array.Reverse(sequences);

        if (sequences[0] == 5)
        {
            Console.WriteLine("Impossible");
        }
        else if (sequences[0] == 4)
        {
            Console.WriteLine("Four of a Kind");
        }
        else if (sequences[0] == 3 && sequences[1] == 2)
        {
            Console.WriteLine("Full House");
        }
        else
        {
            int[] upper = new int[5];
            GetNumericValues(upper, backup, "upper");
            int[] lower = new int[5];
            GetNumericValues(lower, backup, "lower");

            if (CheckForStraight(upper) || CheckForStraight(lower))
            {
                Console.WriteLine("Straight");
            }

            else
            {
                if (sequences[0] == 3)
                {
                    Console.WriteLine("Three of a Kind");
                }
                else if (sequences[0] == 2 && sequences[1] == 2)
                {
                    Console.WriteLine("Two Pairs");
                }
                else if (sequences[0] == 2)
                {
                    Console.WriteLine("One Pair");
                }
                else
                {
                    Console.WriteLine("Nothing");
                }
            }
        }
    }

    static void GetNumericValues(int[] result, string[] hand, string direction)
    {
        int differential = 0;
        if (direction == "upper")
        {
            differential = 13;
        }
        for (int i = 0; i < 5; i++)
        {
            switch (hand[i])
            {
                case "A": result[i] = 1 + differential; break;
                case "J": result[i] = 11; break;
                case "Q": result[i] = 12; break;
                case "K": result[i] = 13; break;
                default: result[i] = int.Parse(hand[i]); break;
            }
        }
    }

    static bool CheckForStraight(int[] hand)
    {
        bool straight = true;
        Array.Sort(hand);

        for (int i = 0; i < 4; i++)
        {
            if (hand[i] + 1 != hand[i + 1])
            {
                straight = false;
            }
        }

        return straight;
    }
}
