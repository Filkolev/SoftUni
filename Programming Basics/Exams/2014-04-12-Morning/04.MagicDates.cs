using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/59

class MagicDates
{
    static void Main()
    {
        int startYear = int.Parse(Console.ReadLine());
        int endYear = int.Parse(Console.ReadLine());
        int magicWeight = int.Parse(Console.ReadLine());

        DateTime startDate = new DateTime(startYear, 1, 1);
        DateTime endDate = new DateTime(endYear, 12, 31);

        int sum = 0;
        bool found = false;

        // Loop through all dates in the interval, convert them to the desired format
        // skip the hyphens and calculate the weight
        for (DateTime currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
        {
            string date = currentDate.ToString("dd-MM-yyyy");

            for (int i = 0; i < date.Length - 1; i++)
            {
                if (i == 2 || i == 5)
                {
                    continue;
                }

                for (int j = i + 1; j < date.Length; j++)
                {
                    if (j == 2 || j == 5)
                    {
                        continue;
                    }

                    int firstDigit = date[i] - 48;
                    int secondDigit = date[j] - 48;
                    sum += firstDigit*secondDigit;
                }              
            }

            if (sum == magicWeight)
            {
                Console.WriteLine(date);
                found = true;           
            }

            sum = 0;
        }

        if (!found)
        {
            Console.WriteLine("No");
        }
    }
}
