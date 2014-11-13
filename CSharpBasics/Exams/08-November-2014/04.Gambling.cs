using System;

class Gambling
{
    static void Main()
    {
		decimal cash = decimal.Parse(Console.ReadLine());
		decimal pot = 2 * cash;

		string[] houseHand = Console.ReadLine().Split();

		int houseStrength = 0;
		for (int i = 0; i < houseHand.Length; i++)
		{
			switch (houseHand[i])
			{
				case "J": houseStrength += 11; break;
				case "Q": houseStrength += 12; break;
				case "K": houseStrength += 13; break;
				case "A": houseStrength += 14; break;
				default: houseStrength += int.Parse(houseHand[i]); break;
			}
		}

		int winningHands = 0;
		int totalHands = 0;
		// const int totalHands = 28561;

		for (int card1 = 2; card1 <= 14; card1++)
		{
			for (int card2 = 2; card2 <= 14; card2++)
			{
				for (int card3 = 2; card3 <= 14; card3++)
				{
					for (int card4 = 2; card4 <= 14; card4++)
					{
						totalHands++;
						int currentHandStrength = card1 + card2 + card3 + card4;

						if (currentHandStrength > houseStrength)
						{
							winningHands++;
						}
					}
				}
			}
		}

		decimal probability = (decimal)winningHands / totalHands;
		decimal expectedWinnings = probability * pot;

		if (probability < 0.5m)
		{
			Console.WriteLine("FOLD");
		}
		else
		{
			Console.WriteLine("DRAW");
		}

		Console.WriteLine("{0:F2}", expectedWinnings);        
    }
}
