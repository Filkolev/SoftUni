using System;

class ChessQueens
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int distance = int.Parse(Console.ReadLine());

        bool found = false;

        for (int q1x = 0; q1x < size; q1x++)
        {
            for (int q1y = 0; q1y < size; q1y++)
            {
                for (int q2x = 0; q2x < size; q2x++)
                {
                    for (int q2y = 0; q2y < size; q2y++)
                    {
                        int xDistance = (Math.Abs(q1x - q2x)) - 1;
                        int yDistance = (Math.Abs(q1y - q2y)) - 1;
                        if (q1x == q2x && yDistance == distance
                            || q1y == q2y && xDistance == distance
                            || xDistance == yDistance && xDistance == distance)
                        {
                            found = true;

                            Console.WriteLine("{0}{1} - {2}{3}", (char)(q1x + 'a'), q1y + 1, (char)(q2x + 'a'), q2y + 1);
                        }
                    }
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("No valid positions");
        }
    }
}
