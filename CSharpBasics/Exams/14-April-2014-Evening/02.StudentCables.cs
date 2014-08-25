using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/86

class StudentCables
{
    static void Main()
    {
        int numberOfCables = int.Parse(Console.ReadLine());

        int totalLength = 0;
        int numberOfCablesUsed = 0;

        for (int i = 0; i < numberOfCables; i++)
        {
            int currentCable = int.Parse(Console.ReadLine());
            string measure = Console.ReadLine();

            if (measure == "meters")
            {
                currentCable *= 100;
            }

            else if (currentCable < 20)
            {
                continue; 
            }

            totalLength += currentCable;
            numberOfCablesUsed++;
        }

        totalLength -= 3 * (numberOfCablesUsed - 1);

        Console.WriteLine(totalLength / 504);
        Console.WriteLine(totalLength % 504);
    }
}
