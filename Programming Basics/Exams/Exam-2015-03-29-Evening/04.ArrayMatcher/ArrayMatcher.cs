namespace _04.ArrayMatcher
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArrayMatcher
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            string[] arrayData = input.Split('\\');

            List<char> resultingChars = new List<char>();

            switch (arrayData[2])
            {
                case "join":
                    JoinArrays(resultingChars, arrayData[0], arrayData[1]);
                    break;
                case "right exclude":
                    Exclude(resultingChars, arrayData[0], arrayData[1]);
                    break;
                case "left exclude":
                    Exclude(resultingChars, arrayData[1], arrayData[0]);
                    break;
            }

            resultingChars.Sort();

            Console.WriteLine(new string(resultingChars.ToArray()));
        }

        private static void JoinArrays(List<char> resultingChars, string leftArray, string rightArray)
        {
            resultingChars.AddRange(leftArray
                .Where(ch => rightArray.Contains(ch.ToString())));
        }

        private static void Exclude(List<char> resultingChars, string leftArray, string rightArray)
        {
            resultingChars.AddRange(leftArray
                .Where(ch => !rightArray.Contains(ch.ToString())));
        }
    }
}
