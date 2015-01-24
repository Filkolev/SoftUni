using System;

class MagicCarNumbers
{
    static void Main()
    {
        int magicWeight = int.Parse(Console.ReadLine());

        int[] letters = { 'A' - 'A' + 1, 
                            'B' - 'A' + 1, 
                            'C' - 'A' + 1, 
                            'E' - 'A' + 1, 
                            'H' - 'A' + 1, 
                            'K' - 'A' + 1, 
                            'M' - 'A' + 1, 
                            'P' - 'A' + 1, 
                            'T' - 'A' + 1, 
                            'X' - 'A' + 1};

        int count = 0;

        for (int digit1 = 0; digit1 < 10; digit1++)
        {
            for (int digit2 = 0; digit2 < 10; digit2++)
            {
                for (int letter1 = 0; letter1 < letters.Length; letter1++)
                {                    

                    for (int letter2 = 0; letter2 < letters.Length; letter2++)
                    {
                        int weight = 40 + 10 * letters[letter1] + 10 * letters[letter2];

                        if (digit1 == digit2)
                        {
                            weight += 4 * digit1;

                            if (weight == magicWeight)
                            {
                                count++;
                            }
                        }

                        else
                        {
                            int weight3AB = weight + 3 * digit1 + digit2;
                            int weightA3B = weight + digit1 + 3 * digit2;
                            int weight2A2B = weight + 2 * digit1 + 2 * digit2;

                            if (weight3AB == magicWeight)
                            {
                                count++;
                            }
                            if (weightA3B == magicWeight)
                            {
                                count++;
                            }
                            if (weight2A2B == magicWeight)
                            {
                                count += 3;
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine(count);
    }
}
