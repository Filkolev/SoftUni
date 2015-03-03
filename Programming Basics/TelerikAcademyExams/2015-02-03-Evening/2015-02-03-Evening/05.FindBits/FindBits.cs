namespace _05.FindBits
{
    using System;

    public class FindBits
    {
        public static void Main()
        {
            const int Mask = 31;

            int searchBits = int.Parse(Console.ReadLine());

            int countOfNumbers = int.Parse(Console.ReadLine());

            int countOfOccurences = 0;

            for (int i = 0; i < countOfNumbers; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                for (int index = 0; index < 25; index++)
                {
                    int currentBitSequence = (currentNumber >> index) & Mask;

                    if (currentBitSequence == searchBits)
                    {
                        countOfOccurences++;
                    }
                }
            }

            Console.WriteLine(countOfOccurences);
        }
    }
}