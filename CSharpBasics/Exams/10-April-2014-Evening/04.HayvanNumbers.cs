using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/28

class HayvanNumbers
{
    static void Main()
    {
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());

        bool found = false;

        for (int firstTriplet = 555; firstTriplet <= 999 - 2 * diff; firstTriplet++)
        {
            int secondTriplet = firstTriplet + diff;
            int thirdTriplet = secondTriplet + diff;

            bool numberAllowed = IsAllowed(firstTriplet) && IsAllowed(secondTriplet) && IsAllowed(thirdTriplet);

            int sumOfDigits = GetDigitSum(firstTriplet) + GetDigitSum(secondTriplet) + GetDigitSum(thirdTriplet);

            if (numberAllowed && sumOfDigits == sum)
            {
                Console.WriteLine("{0}{1}{2}", firstTriplet, secondTriplet, thirdTriplet);
                found = true;
            }           
        }

        if (!found)
        {
            Console.WriteLine("No");
        }
    }

    static int GetDigitSum(int triplet)
    {
        int sum = 0;

        sum += triplet % 10;
        sum += (triplet / 10) % 10;
        sum += triplet / 100;

        return sum;
    }

    static bool IsAllowed(int triplet)
    {
        bool allowed = true;

        if ((triplet % 10 < 5) || ((triplet / 10) % 10 < 5))
        {
            allowed = false;
        }

        return allowed;
    }
}
