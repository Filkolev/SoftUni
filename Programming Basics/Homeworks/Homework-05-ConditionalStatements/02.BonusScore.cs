using System;

/* Write a program that applies bonus score to given score in the range [1…9] by the following rules:
•	If the score is between 1 and 3, the program multiplies it by 10.
•	If the score is between 4 and 6, the program multiplies it by 100.
•	If the score is between 7 and 9, the program multiplies it by 1000.
•	If the score is 0 or more than 9, the program prints “invalid score”. */


class BonusScore
{
    static void Main()
    {
        Console.Write("Please enter the initial score (number between 1 and 9: ");
        int score = int.Parse(Console.ReadLine());
        int result = score; 

        switch (score)
        {
            case 1: 
            case 2:
            case 3:
                result *= 10;
                break;
            case 4:
            case 5:
            case 6:
                result *= 100;
                break;
            case 7:
            case 8:
            case 9:
                result *= 1000;                
                break;
            default: Console.WriteLine("\nInvalid score!\n");
                return;                
        }

        Console.WriteLine("\nThe score after applying the appropriate bonus is: {0}\n", result);        
    }
}
