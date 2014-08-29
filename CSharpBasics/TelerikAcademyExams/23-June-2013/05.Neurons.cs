using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/443

class Neurons
{
    static void Main()
    {     
        string input = Console.ReadLine();

        while (input != "-1")
        {
            uint currentNum = uint.Parse(input);

            if (currentNum != 0)
            {
                int startIndex = 0;
                int endIndex = 0;

                for (int index = 0; index < 32; index++)
                {
                    uint bit = (currentNum >> index) & 1;
                    bool done = false;

                    if (bit == 1)
                    {

                        for (int tempIndex = index + 1; tempIndex < 32; tempIndex++)
                        {
                            uint tempBit = (currentNum >> tempIndex) & 1;
                            if (tempBit == 0)
                            {
                                startIndex = tempIndex;
                                break;
                            }
                        }

                        if (startIndex != 0)
                        {
                            for (int tempIndex = startIndex + 1; tempIndex < 32; tempIndex++)
                            {
                                uint tempBit = (currentNum >> tempIndex) & 1;
                                if (tempBit == 1)
                                {
                                    endIndex = tempIndex - 1;
                                    break;
                                }

                                if (tempIndex == 31)
                                {
                                    done = true;
                                }
                            }
                        }
                    }

                    if (done || (startIndex != 0 && endIndex != 0))
                    {
                        break;
                    }
                }

                if (startIndex == 0)
                {
                    currentNum = 0;                   
                }

                else
                {
                    for (int index = 0; index < 32; index++)
                    {
                        uint bit = (currentNum >> index) & 1;

                        if (bit == 1)
                        {
                            uint mask = ~(1u << index);
                            currentNum = currentNum & mask;
                        }

                        else
                        {
                            if (index >= startIndex && index <= endIndex)
                            {
                                uint mask = 1u << index;
                                currentNum = currentNum | mask;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(currentNum);

            input = Console.ReadLine();
        }
    }
}
