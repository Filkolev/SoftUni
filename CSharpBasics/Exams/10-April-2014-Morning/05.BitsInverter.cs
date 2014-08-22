using System;

// Find problem here: http://judge.softuni.bg/Contests/Practice/DownloadResource/20

class BitsInverter
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());

        int[] bytes = new int[n];

        for (int i = 0; i < n; i++)
        {
            bytes[i] = int.Parse(Console.ReadLine());
        }

        int position = 7;

        for (int i = 0; i < n; i++)
        {
            while (position >= 0)
            {
                int currentBit = (bytes[i] >> position) & 1;

                if (currentBit == 0)
                {
                    bytes[i] = (1 << position) | bytes[i];
                }
                else
                {
                    bytes[i] = ~(1 << position) & bytes[i];
                }

                position -= step;
            }

            Console.WriteLine(bytes[i]);

            position += 8;
        }
    }
}
