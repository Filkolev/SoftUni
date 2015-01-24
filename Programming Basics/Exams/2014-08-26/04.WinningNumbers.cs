using System;

class WinningNumbers
{
    static void Main()
    {
        string input = Console.ReadLine().ToLower();

        int sum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            sum += (input[i] - 'a' + 1);
        }

        bool found = false;

        for (int i = 111; i <= 999; i++)
        {
            for (int j = 111; j <= 999; j++)
            {
                if (sum == GetProduct(i) && sum == GetProduct(j))
                {
                    Console.WriteLine("{0}-{1}", i, j);
                    found = true;
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("No");
        }
    }

    static int GetProduct(int num)
    {
        int product = 1;

        product *= (num / 100);
        product *= (num / 10) % 10;
        product *= (num % 10);

        return product;
    }
}
