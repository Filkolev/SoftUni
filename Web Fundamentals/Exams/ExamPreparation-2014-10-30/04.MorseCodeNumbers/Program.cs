using System;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int digitSum = 0;

        bool found = false;

        string[] codes = 
        { ".----", "..---", "...--", "....-", "....." };

        while (number > 0)
        {
            int digit = number % 10;
            digitSum += digit;
            number = number / 10;
        }

        for (int num1 = 1; num1 <= 5; num1++)
        {
            for (int num2 = 1; num2 <= 5; num2++)
            {
                for (int num3 = 1; num3 <= 5; num3++)
                {
                    for (int num4 = 1; num4 <= 5; num4++)
                    {
                        for (int num5 = 1; num5 <= 5; num5++)
                        {
                            for (int num6 = 1; num6 <= 5; num6++)
                            {
                                int product = num1 * num2 * num3 * num4 * num5 * num6;

                                if (product == digitSum)
                                {
                                    found = true;
                                    Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|", 
                                        codes[num1 - 1], codes[num2 - 1],codes[num3 - 1],codes[num4 - 1],codes[num5 - 1], codes[num6 - 1]);
                                }
                            }
                        }
                    }
                }
            }
        }

        if (found == false)
        {
            Console.WriteLine("No");
        }

    }
}
