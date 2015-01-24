using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/51

class CatchTheBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());      
        
        int currentPosition = 6; 
        int numberOfBits = 0;
        int resultingNumber = 0;        

        for (int i = 0; i < n; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());
           
            while (currentPosition >= 0)
            {
                int currentBit = (currentNumber >> currentPosition) & 1; 
                resultingNumber = (resultingNumber << 1) | currentBit; 
                numberOfBits++; 
                currentPosition -= step;

                // When a byte is completed, print it
                // reset the number of bits and resulting number variables
                if (numberOfBits == 8)
                {
                    Console.WriteLine(resultingNumber);
                    resultingNumber = 0;
                    numberOfBits = 0;                                   
                }                
            }

            // If the loop is at the last step and there are bits left over
            if (numberOfBits != 0 && i == n - 1)
            {
                resultingNumber = resultingNumber << (8 - numberOfBits);
                Console.WriteLine(resultingNumber);                
            }
                     
            currentPosition += 8; 

        }  
    }
}
