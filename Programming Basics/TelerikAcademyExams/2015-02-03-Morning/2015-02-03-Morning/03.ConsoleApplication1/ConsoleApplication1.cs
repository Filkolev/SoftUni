namespace _03.ConsoleApplication1
{
    using System;
    using System.Numerics;

    public class ConsoleApplication1
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            BigInteger product = 1;

            int index = 0;
            while (input != "END")
            {
                BigInteger currentProduct = 1;
                if (index % 2 == 1 && input != "0")
                {
                    foreach (var symbol in input)
                    {
                        int digit = symbol - '0';

                        if (digit != 0)
                        {
                            currentProduct *= digit;
                        }
                    }
                }

                product *= currentProduct;

                if (index == 9)
                {
                    Console.WriteLine(product);
                    product = 1;
                }

                index++;
                input = Console.ReadLine();
            }

            Console.WriteLine(product);
        }
    }
}
