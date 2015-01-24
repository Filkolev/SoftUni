using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/30

class BitsUp
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        byte step = byte.Parse(Console.ReadLine());        

        int currentPosition = 6;
        
        for (int i = 0; i < n; i++)
        {
            int currentByte = int.Parse(Console.ReadLine());

            // While the current position is still within the current byte, keep putting 1s in place of 0s
            while (currentPosition >= 0)
            {
                int currentBit = (currentByte >> currentPosition) & 1;
                if (currentBit == 0)
                {
                    currentByte = (1 << currentPosition) | currentByte;
                }
                
                currentPosition -= step;
            }

            // Before moving to the next byte, print the modified current byte
            Console.WriteLine(currentByte);
            
            currentPosition += 8;
        }       
       
    }
}
