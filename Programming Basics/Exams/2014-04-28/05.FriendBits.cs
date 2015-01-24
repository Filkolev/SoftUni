using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/108

class FriendBits
{
    static void Main()
    {
        uint input = uint.Parse(Console.ReadLine());  

        uint friendBits = 0;
        uint aloneBits = 0;

        int leftmostBit = 0;
        uint temp = input;

        while (temp > 0)
        {
            temp >>= 1;
            leftmostBit++;
        }

        uint previousBit = 0;
        uint currentBit = 0;
        uint nextBit = 0;

        while (leftmostBit > 1)
        {
            nextBit = (input >> leftmostBit - 2) & 1;            
            currentBit = (input >> leftmostBit - 1) & 1;

            if (currentBit == nextBit)
            {
                friendBits <<= 1;
                friendBits |= currentBit;
            }

            else if (currentBit == previousBit)
            {
                friendBits <<= 1;
                friendBits |= currentBit;
            }

            else
            {
                aloneBits <<= 1;
                aloneBits |= currentBit;
            }

            previousBit = currentBit;

            leftmostBit--;           
        }

        uint firstBit = input & 1;

        if (firstBit == previousBit)
        {
            friendBits <<= 1;
            friendBits |= firstBit;
        }

        else
        {
            aloneBits <<= 1;
            aloneBits |= firstBit;
        }

        Console.WriteLine(friendBits);
        Console.WriteLine(aloneBits);
    }
}
