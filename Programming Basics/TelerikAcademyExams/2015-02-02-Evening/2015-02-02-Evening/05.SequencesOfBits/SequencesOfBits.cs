namespace _05.SequencesOfBits
{
    using System;
    using System.Text;

    public class SequencesOfBits
    {
        public static void Main()
        {
            int countOfNumbers = int.Parse(Console.ReadLine());
            StringBuilder bitSequence = new StringBuilder();

            ConstructBitSequence(countOfNumbers, bitSequence);

            int maxOneSequence = 0;
            int maxZeroSequence = 0;
            int currentSequence = 1;

            char currentSymbol = bitSequence[0];

            for (int i = 1; i < bitSequence.Length; i++)
            {
                if (bitSequence[i] == currentSymbol)
                {
                    currentSequence++;

                    if (i == bitSequence.Length - 1)
                    {
                        UpdateMaxSequenceCounters(currentSymbol, currentSequence, ref maxZeroSequence, ref maxOneSequence);
                    }
                }
                else
                {
                    UpdateMaxSequenceCounters(currentSymbol, currentSequence, ref maxZeroSequence, ref maxOneSequence);

                    currentSequence = 1;
                    currentSymbol = currentSymbol == '0' ? '1' : '0';
                }
            }

            Console.WriteLine(maxOneSequence);
            Console.WriteLine(maxZeroSequence);
        }

        private static void UpdateMaxSequenceCounters(
            char currentSymbol,
            int currentSequence,
            ref int maxZeroSequence,
            ref int maxOneSequence)
        {
            if (currentSymbol == '0' && currentSequence > maxZeroSequence)
            {
                maxZeroSequence = currentSequence;
            }
            else if (currentSymbol == '1' && currentSequence > maxOneSequence)
            {
                maxOneSequence = currentSequence;
            }
        }

        private static void ConstructBitSequence(int countOfNumbers, StringBuilder bitSequence)
        {
            for (int i = 0; i < countOfNumbers; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                string binaryNumberRepresentation = Convert.ToString(currentNumber, 2).PadLeft(30, '0');

                bitSequence.Append(binaryNumberRepresentation);
            }
        }
    }
}