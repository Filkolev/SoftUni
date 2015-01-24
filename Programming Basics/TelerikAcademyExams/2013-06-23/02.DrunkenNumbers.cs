using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/440

class DrunkenNumbers
{
	public static void Main()
	{
		int totalRounds = int.Parse(Console.ReadLine());
		
		int mitko = 0;
		int vladko = 0;
		
		for	(int round = 0; round < totalRounds; round++)
		{
			string currentNumber = Math.Abs(int.Parse(Console.ReadLine())).ToString(); 
			// Get the input, parse it to string to eliminate leading zeros, get its absolute value in case it's negative and convert it back to string			
			
			for (int digit = 0; digit < currentNumber.Length; digit++)
			{
				if (digit < currentNumber.Length / 2)
				{
					mitko += currentNumber[digit] - '0';				
				}		
				
				else
				{
					vladko += currentNumber[digit] - '0';
				}				
			}
			
			// if the number of digits is odd, the middle digit will be added to only vladko in the loop, add it to mitko as well
			if (currentNumber.Length % 2 != 0)
				{
					mitko += currentNumber[currentNumber.Length/2] - 48;
				}	
		}
		
		if (mitko == vladko)
		{
			Console.WriteLine("No {0}", mitko + vladko);
		}
		
		else if (mitko > vladko)
		{
			Console.WriteLine("M {0}", mitko - vladko);
		}
		
		else
		{
			Console.WriteLine("V {0}", vladko - mitko);
		}		
	}	
}
