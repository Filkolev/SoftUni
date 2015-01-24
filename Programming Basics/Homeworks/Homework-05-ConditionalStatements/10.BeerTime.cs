using System;

/* A beer time is after 1:00 PM and before 3:00 AM. Write a program that 
  enters a time in format “hh:mm tt” (an hour in range [01...12], a minute in 
  range [00…59] and AM / PM designator) and prints “beer time” or “non-beer time” 
  according to the definition above or “invalid time” if the time cannot be parsed. 
  Note that you may need to learn how to parse dates and times. */

class BeerTime
{
    static void Main()
    {
        Console.Write("Enter the time of day to check if it's beer time: ");
        string input = Console.ReadLine();
        
        DateTime isBeer;
        bool isParsed = DateTime.TryParse(input, out isBeer);

        if (!isParsed)
        {
            Console.WriteLine("\ninvalid time\n");
        }

        else if (isBeer.TimeOfDay < DateTime.Parse("03:00 AM").TimeOfDay || isBeer.TimeOfDay >= DateTime.Parse("01:00 PM").TimeOfDay)
        {
            Console.WriteLine("\nbeer time\n");
        }

        else
        {
            Console.WriteLine("\nnon-beer time\n");
        }        
    }
}
