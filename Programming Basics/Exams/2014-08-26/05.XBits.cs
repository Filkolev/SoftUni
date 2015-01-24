using System;

class XBits
{
    static void Main()
    {
        int[] numbers = new int[8];

        for (int i = 0; i < 8; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int mask = 7;
        int count = 0;

        for (int number = 0; number <= 5; number++)
        {
            for (int position = 0; position <= 28; position++)
            {
                if (((numbers[number] >> position) & mask) == 5)
                {
                    if (((numbers[number + 1] >> position) & mask) == 2)
                    {
                        if (((numbers[number + 2] >> position) & mask) == 5)
                        {
                            count++;
                        }
                    }
                }
            }
        }

        Console.WriteLine(count);
    }
}
