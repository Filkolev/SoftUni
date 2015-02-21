namespace Numbers
{
    using System;

    public static class NumberMethods
    {
        public static string DigitToWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            throw new ArgumentOutOfRangeException(
                "number", 
                "The number should be a valid digit in the range [0 ... 9].");
        }

        public static int FindMax(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Parameter list cannot be empty", "numbers");
            }

            int max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }
        
        /// <summary>
        /// Prints a numeric value in a specified format.
        /// </summary>
        /// <param name="number">The number to be printed.</param>
        /// <param name="format">The format to be used when printing the number. 
        /// "f" prints the number with two digits after the decimal separator; 
        /// "%" converts a number to percent (e.g. 0.75 is printed as "75 %");
        /// "r" aligns the number 8 places to the right.
        /// </param>
        public static void PrintNumberInFormat(object number, string format)
        {
            if (!IsNumeric(number))
            {
                throw new ArgumentException("The object is not a numeric value.", "number");
            }

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("The specified format was not recognized.", "format");
            }
        }

        private static bool IsNumeric(object number)
        {
            if ((number is sbyte) ||
                (number is byte) ||
                (number is short) ||
                (number is ushort) ||
                (number is int) ||
                (number is uint) ||
                (number is float) ||
                (number is double) ||
                (number is decimal))
            {
                return true;
            }

            return false;
        }
    }
}
