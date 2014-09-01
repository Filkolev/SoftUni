using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/5

class SubsetSums
{
    static void Main()
    {
        long sum = long.Parse(Console.ReadLine());

        int countOfNumbers = int.Parse(Console.ReadLine());

        long[] numbers = new long[countOfNumbers];

        for (int i = 0; i < countOfNumbers; i++)
        {
            numbers[i] = long.Parse(Console.ReadLine());
        }

        int mask = (1 << countOfNumbers) - 1;
        int result = 0;

        for (int i = 1; i <= mask; i++)
        {
            char[] indexesToTake = Convert.ToString(i, 2).PadLeft(countOfNumbers, '0').ToCharArray();

            long currentSum = 0;

            for (int j = 0; j < countOfNumbers; j++)
            {
                if (indexesToTake[j] == '1')
                {
                    currentSum += numbers[j];
                }
            }

            if (currentSum == sum)
            {
                result++;
            }
        }

        Console.WriteLine(result);
    }
}
