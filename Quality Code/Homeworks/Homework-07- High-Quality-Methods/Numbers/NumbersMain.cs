namespace Numbers
{
    using System;

    public class NumbersMain
    {
        public static void Main()
        {
            Console.WriteLine(NumberMethods.DigitToWord(5));

            int max = NumberMethods.FindMax(5, -1, 3, 2, 14, 2, 3);
            Console.WriteLine(max);

            NumberMethods.PrintNumberInFormat(1.3, "f");
            NumberMethods.PrintNumberInFormat(0.75, "%");
            NumberMethods.PrintNumberInFormat(2.30, "r");
        }
    }
}
