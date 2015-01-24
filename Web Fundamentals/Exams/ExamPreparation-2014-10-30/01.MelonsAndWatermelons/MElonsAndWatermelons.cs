using System;

class MelonsAndWatermelons
{
    static void Main()
    {
        int startDay = int.Parse(Console.ReadLine());
        int days = int.Parse(Console.ReadLine());

        int countMelons = 0;
        int countWatermelons = 0;

        int fullWeeks = days / 7;
        int remainingDays = days % 7;

        countMelons = fullWeeks * 7;
        countWatermelons = fullWeeks * 7;

        for (int i = startDay; i < startDay + remainingDays; i++)
        {
            int dayOfWeek = (i % 7);

            switch (dayOfWeek)
            {
                case 1: countWatermelons++; break;
                case 2: countMelons += 2; break;
                case 3: countMelons++; countWatermelons++; break;
                case 4: countWatermelons += 2; break;
                case 5: countWatermelons += 2; countMelons += 2; break;
                case 6: countWatermelons++; countMelons += 2; break;
            }
        }

        if (countWatermelons == countMelons)
        {
            Console.WriteLine("Equal amount: {0}", countMelons);
        }

        else if (countMelons > countWatermelons)
        {
            Console.WriteLine("{0} more melons", countMelons - countWatermelons);
        }
        else
        {
            Console.WriteLine("{0} more watermelons", countWatermelons - countMelons);
        }
    }
}
