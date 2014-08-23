using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/69

class FiveSpecialLetters
{
    static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());

        char[] letters = { 'a', 'b', 'c', 'd', 'e' };

        bool found = false;

        // Loop through all possible combinations, calculate weight and print the string if it's within the desired boundaries
        for (int i1 = 0; i1 < 5; i1++)
        {
            for (int i2 = 0; i2 < 5; i2++)
            {
                for (int i3 = 0; i3 < 5; i3++)
                {
                    for (int i4 = 0; i4 < 5; i4++)
                    {
                        for (int i5 = 0; i5 < 5; i5++)
                        {
                            string currentString = "" + letters[i1] + letters[i2] + letters[i3] + letters[i4] + letters[i5];
                            
                            int weightOfPosition = 0;
                            int totalWeight = 0;                            

                            // Check if the letter hasn't been used
                            for (int currentLetterIndex = 0; currentLetterIndex < 5; currentLetterIndex++)
                            {
                                bool isUnique = true;
                                int weightOfLetter = 0;

                                for (int previousIndices = currentLetterIndex - 1; previousIndices >= 0; previousIndices--)
                                {
                                    if (currentString[currentLetterIndex] == currentString[previousIndices])
                                    {
                                        isUnique = false;
                                    }
                                }

                                if (isUnique)
                                {
                                    weightOfPosition++;
                                    switch (currentString[currentLetterIndex])
                                    {
                                        case 'a': weightOfLetter = 5;
                                            break;
                                        case 'b': weightOfLetter = -12;
                                            break;
                                        case 'c': weightOfLetter = 47;
                                            break;
                                        case 'd': weightOfLetter = 7;
                                            break;
                                        case 'e': weightOfLetter = -32;
                                            break;
                                    }

                                    totalWeight += weightOfPosition * weightOfLetter;
                                }

                                
                                // At the last step, if the total weight is between start and end, print the string
                                if (currentLetterIndex == 4)
                                {
                                    if (totalWeight >= start && totalWeight <= end)
                                    {
                                        Console.Write("{0} ", currentString);
                                        found = true;
                                    }

                                    // Before starting over, reset totalWeight and weightOfPosition
                                    totalWeight = 0;
                                    weightOfPosition = 0;
                                }
                            }
                        }
                    }
                }
            }
        }
        
        if (!found)
        {
            Console.WriteLine("No");
        }

    }
}
