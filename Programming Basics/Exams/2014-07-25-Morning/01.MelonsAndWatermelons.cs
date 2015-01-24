using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/165

class MelonsAndWatermelons
{
    static void Main()
    {
        int startingDay = int.Parse(Console.ReadLine());
        int numberOfDays = int.Parse(Console.ReadLine());

        int countOfMelons = 0;
        int countOfWatermelons = 0;

        int fullWeeks = numberOfDays / 7;

        countOfMelons += fullWeeks * 7;
        countOfWatermelons += fullWeeks * 7;

        int remainingDays = numberOfDays % 7;

        for (int currentDay = startingDay; currentDay < startingDay + remainingDays; currentDay++)
        {
            int dayOfWeek = currentDay % 7;

            switch (dayOfWeek)
            {
                case 1:
                    countOfWatermelons++;
                    break;
                case 2:
                    countOfMelons += 2;
                    break;
                case 3:
                    countOfMelons++;
                    countOfWatermelons++;
                    break;
                case 4:
                    countOfWatermelons += 2;
                    break;
                case 5:
                    countOfMelons += 2;
                    countOfWatermelons += 2;
                    break;
                case 6:
                    countOfWatermelons++;
                    countOfMelons += 2;
                    break;
            }
        }


        if (countOfMelons == countOfWatermelons)
        {
            Console.WriteLine("Equal amount: {0}", countOfMelons);
        }

        else if (countOfMelons > countOfWatermelons)
        {
            Console.WriteLine("{0} more melons", countOfMelons - countOfWatermelons);
        }

        else
        {
            Console.WriteLine("{0} more watermelons", countOfWatermelons - countOfMelons);
        }
    }
}
