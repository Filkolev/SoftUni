using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/439

class CoffeeMachine
{
	public static void Main()
	{
        int[] trays = new int[5];

        for (int i = 0; i < 5; i++)
        {
            trays[i] = int.Parse(Console.ReadLine());
        }		
		
		decimal paid = decimal.Parse(Console.ReadLine());
		decimal price = decimal.Parse(Console.ReadLine());		
		
		if (paid < price)
		{
			Console.WriteLine("More {0:f2}", price  - paid);
		}
		
		else
		{
			decimal change = paid - price;
			
			while (change >= 1.0m && trays[4] > 0)
			{
				change--;
                		trays[4]--;
			}
			
			while (change >= 0.5m && trays[3] > 0)
			{
				change -= 0.5m;
                		trays[3]--;
			}
			
			while (change >= 0.2m && trays[2] > 0)
			{
				change -= 0.2m;
                		trays[2]--;
			}
			
			while (change >= 0.1m && trays[1] > 0)
			{
				change -= 0.1m;
                		trays[1]--;
			}
			
			while (change >= 0.05m && trays[0] > 0)
			{
				change -= 0.05m;
                		trays[0]--;
			}
			
			decimal trayTotal = trays[0] * 0.05m + trays[1] * 0.1m + trays[2] * 0.2m + trays[3] * 0.5m + trays[4];
			
			if (change == 0)
			{				
				Console.WriteLine("Yes {0:f2}", trayTotal);
			}
			
			else 
			{
				Console.WriteLine("No {0:f2}", change); 
			}					
		}		
	}
}
