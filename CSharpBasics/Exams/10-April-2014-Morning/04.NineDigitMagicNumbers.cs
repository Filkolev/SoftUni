using System;

// Find problem here: http://judge.softuni.bg/Contests/Practice/DownloadResource/18

class NineDigitMagicNumbers
{
    static void Main()
    {            
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
            
        bool magicFound = false;
            
        for (int firstTriplet = 111; firstTriplet <= 777 - 2 * diff; firstTriplet++)
        {
            int secondTriplet = firstTriplet + diff;
            int thirdTriplet = secondTriplet + diff;

            int digitSum = GetDigitSum(firstTriplet) + GetDigitSum(secondTriplet) + GetDigitSum(thirdTriplet);

            if (NumberAllowed(firstTriplet) && NumberAllowed(secondTriplet) && NumberAllowed(thirdTriplet) && digitSum == sum)
            {
                Console.WriteLine("{0}{1}{2}", firstTriplet, secondTriplet, thirdTriplet);

                magicFound = true;
            }                        
                
        }
            
        if (!magicFound)
        {
            Console.WriteLine("No");
        }
    }

    static bool NumberAllowed(int triplet)
    {
        bool isAllowed = false;

        if (triplet % 10 > 0 
            && (triplet / 10) % 10 > 0 
            && triplet % 10 < 8 
            && (triplet / 10) % 10 < 8) 
        {
            isAllowed = true;
        }

        return isAllowed;
    }

    static int GetDigitSum(int triplet)
    {
        int sum = 0;
        sum += triplet / 100;       // add digit of hundreds
        sum += (triplet / 10) % 10; // tens
        sum += triplet % 10;        // ones

        return sum;
    }
}
