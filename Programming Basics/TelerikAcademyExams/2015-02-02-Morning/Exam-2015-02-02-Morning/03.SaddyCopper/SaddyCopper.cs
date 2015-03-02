namespace _03.SaddyCopper
{
    using System;
    using System.Numerics;

    public class SaddyCopper
    {
        public static void Main()
        {
            string number = Console.ReadLine();

            BigInteger product = 1;
            int countOfTransormations = 0;

            while (true)
            {
                while (number.Length > 1)
                {
                    number = number.Substring(0, number.Length - 1);

                    int sumOfEvenDigits = 0;

                    for (int i = 0; i < number.Length; i += 2)
                    {
                        int currentDigit = number[i] - '0';
                        sumOfEvenDigits += currentDigit;
                    }

                    product *= sumOfEvenDigits;
                }

                countOfTransormations++;

                if (countOfTransormations == 10)
                {
                    Console.WriteLine(product);
                    break;
                }

                if (product < 10)
                {
                    Console.WriteLine(countOfTransormations);
                    Console.WriteLine(product);
                    break;
                }

                number = product.ToString();
                product = 1;
            }
        }
    }
}
