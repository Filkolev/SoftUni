using System;
using System.Linq;
using System.Collections.Generic;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/7

class LeastMajorityMultiple
{
    static void Main(string[] args)
    {       
        long leastMultiple = long.MaxValue;

        int[] numbers = new int[5];

        for (int i = 0; i < 5; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int mask = (1 << 5) - 1;

        for (int i = 7; i <= mask; i++)
        {
            if (CountOneBits(i) >= 3)
            {
                char[] getNumbers = Convert.ToString(i, 2).PadLeft(5, '0').ToCharArray();
                List<int> currentNums = new List<int>(CountOneBits(i));

                for (int j = 0; j < 5; j++)
                {
                    if (getNumbers[j] == '1')
                    {
                        currentNums.Add(numbers[j]);
                    }
                }

                long multiple = 1;

                for (int divisor = 2; divisor <= currentNums.Max(); divisor++)
                {                    
                    for (int k = 0; k < currentNums.Count; k++)
                    {
                        bool added = false;

                        if (currentNums[k] % divisor == 0)
                        {
                            DivideAll(currentNums, divisor);

                            if (!added)
                            {
                                multiple *= divisor;
                            }
                        }
                    }                   

                }

                foreach (var num in currentNums)
                {
                    multiple *= num;
                }

                if (multiple < leastMultiple)
                {
                    leastMultiple = multiple;
                }                
            }
        }

        Console.WriteLine(leastMultiple);
    }

    static int CountOneBits(int num)
    {
       int count = 0;

       while (num > 0)
       {
           int bit = num & 1;
           count += bit;
           num >>= 1;
       }

       return count;
    }   

    static void DivideAll(List<int> nums, int divisor)
    {
        for (int i = 0; i < nums.Count; i++)
        {
            if (nums[i] % divisor == 0)
            {
                nums[i] /= divisor;
            }
        }
    }
}
