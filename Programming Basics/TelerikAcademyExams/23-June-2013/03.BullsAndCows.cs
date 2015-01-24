using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/441

class BullsAndCows
{
    static void Main()
    {
        string input = Console.ReadLine();

        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        int results = 0;
        int countOfBulls = 0;
        int countOfCows = 0;

        if (b > 4 || c > 4)
        {
            Console.WriteLine("No");
            return;
        }

        for (int guessNumber = 1111; guessNumber <= 9999; guessNumber++)
        {
            char[] secretNumber = { input[0], input[1], input[2], input[3] };
            string guess = guessNumber.ToString();
            char[] guessNumChars = { guess[0], guess[1], guess[2], guess[3] };

            if (guess[1] == '0' || guess[2] == '0' || guess[3] == '0')
            {
                continue;
            }

            for (int i = 0; i < 4; i++)
            {
                if (guessNumChars[i] == secretNumber[i])
                {
                    countOfBulls++;
                    guessNumChars[i] = '#';
                    secretNumber[i] = '!';
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (guessNumChars[i] == secretNumber[j])
                    {
                        countOfCows++;
                        guessNumChars[i] = '#';
                        secretNumber[j] = '!'; 
                    }                    
                }
            }

            if (countOfBulls == b && countOfCows == c)
            {
                Console.Write("{0} ",guess);
                results++;
            }

            countOfBulls = 0;
            countOfCows = 0;
        }

        if (results==0)
        {
            Console.WriteLine("No");
        }
    }
}
