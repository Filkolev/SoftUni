using System;

class WeirdCombinations
{
    static void Main()
    {
        string sequence = Console.ReadLine();
        int index = int.Parse(Console.ReadLine());

        if (index >= 3125)
        {
            Console.WriteLine("No");
            return;
        }

        int count = 0;

        for (int ch1 = 0; ch1 < 5; ch1++)
        {
            for (int ch2 = 0; ch2 < 5; ch2++)
            {
                for (int ch3 = 0; ch3 < 5; ch3++)
                {
                    for (int ch4 = 0; ch4 < 5; ch4++)
                    {
                        for (int ch5 = 0; ch5 < 5; ch5++)
                        {
                            if (count == index)
                            {
                                Console.WriteLine("" + sequence[ch1] + sequence[ch2] + sequence[ch3] + sequence[ch4] + sequence[ch5]);
                            }

                            count++;
                        }
                    }
                }
            }
        }       
    }
}
