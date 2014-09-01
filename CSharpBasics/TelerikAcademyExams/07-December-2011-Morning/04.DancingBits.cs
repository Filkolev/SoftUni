using System;
using System.Text;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/24

class DancingBits
{
    static void Main()
    {
        StringBuilder prelimString = new StringBuilder();

        int length = int.Parse(Console.ReadLine());

        int numberOfInputs = int.Parse(Console.ReadLine());

        int dancingBits = 0;
        int currentIndex = 0;

        for (int i = 0; i < numberOfInputs; i++)
        {
            int currentNum = int.Parse(Console.ReadLine());
            string binary = Convert.ToString(currentNum, 2);
            prelimString.Append(binary);
        }

        string sequence = prelimString.ToString();

        if (sequence.Length == length)
        {
            if (sequence == new string('0', length) || sequence == new string('1', length))
            {
                dancingBits++;
            }
        }

        else if (sequence.Length == length + 1)
        {
            // Check left border
            string leftBorder = sequence.Substring(0, length + 1);
            string zeroDance = new string('0', length) + "1";
            string onesDance = new string('1', length) + "0";

            if (leftBorder == zeroDance || leftBorder == onesDance)
            {
                dancingBits++;
                currentIndex += Math.Max(0, (length - 2));
            }

            // Check right border
            string rightBorder = sequence.Substring(sequence.Length - length - 1, length + 1);
            zeroDance = "1" + new string('0', length);
            onesDance = "0" + new string('1', length);

            if (rightBorder == zeroDance || rightBorder == onesDance)
            {
                dancingBits++;
            }
        }

        else if (sequence.Length >= length + 2)
        {
            // Check left border
            string leftBorder = sequence.Substring(0, length + 1);
            string zeroDance = new string('0', length) + "1";
            string onesDance = new string('1', length) + "0";

            if (leftBorder == zeroDance || leftBorder == onesDance)
            {
                dancingBits++;
                currentIndex += Math.Max(0, (length - 2));
            }

            // check body
            zeroDance = "1" + new string('0', length) + "1";
            onesDance = "0" + new string('1', length) + "0";

            for (int i = currentIndex; i <= sequence.Length - length - 2; i++)
            {
                string currentSequence = sequence.Substring(i, length + 2);

                if (currentSequence == zeroDance || currentSequence == onesDance)
                {
                    dancingBits++;
                    i += length - 1;
                }
            }

            // Check right border
            string rightBorder = sequence.Substring(sequence.Length - length - 1, length + 1);
            zeroDance = "1" + new string('0', length);
            onesDance = "0" + new string('1', length);

            if (rightBorder == zeroDance || rightBorder == onesDance)
            {
                dancingBits++;
            }
        }

        Console.WriteLine(dancingBits);
    }
}
