namespace _04.EncryptedMessage
{
    using System;
    using System.Text;

    public class EncryptedMatrix
    {
        public static void Main()
        {
            string message = Console.ReadLine();
            string diagonal = Console.ReadLine();
            StringBuilder unencryptedNumber = new StringBuilder();

            foreach (char symbol in message)
            {
                unencryptedNumber.Append(symbol % 10);
            }

            StringBuilder encryptedNumber = new StringBuilder();

            for (int i = 0; i < unencryptedNumber.Length; i++)
            {
                int currentDigit = unencryptedNumber[i] - '0';

                int resultingDigit;

                if (currentDigit % 2 == 0)
                {
                    resultingDigit = currentDigit * currentDigit;
                }
                else
                {
                    int leftDigit = i == 0 ? 0 : unencryptedNumber[i - 1] - '0';
                    int rightDigit = i == unencryptedNumber.Length - 1 ? 0 : unencryptedNumber[i + 1] - '0';
                    resultingDigit = currentDigit + leftDigit + rightDigit;
                }

                encryptedNumber.Append(resultingDigit);
            }

            int position;
            int update;

            if (diagonal == "\\")
            {
                position = 0;
                update = 1;
            }
            else
            {
                position = encryptedNumber.Length - 1;
                update = -1;
            }

            for (int i = 0; i < encryptedNumber.Length; i++)
            {
                for (int j = 0; j < encryptedNumber.Length; j++)
                {
                    if (j == position)
                    {
                        Console.Write(encryptedNumber[position] + " ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }

                Console.WriteLine();

                position += update;
            }
        }
    }
}
