namespace _01.StringBuilderExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Tests the correctness of the StringBuilder extension methods.
    /// </summary>
    public class StringBuilderExtensionsTest
    {
        public static void Main()
        {
            StringBuilder sb = new StringBuilder("asfsfdgd");
            Console.WriteLine(sb.Substring(5, 3));
            Console.WriteLine(sb.Substring(5, 5));

            sb.RemoveText("sf");
            Console.WriteLine(sb);

            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };

            sb.AppendAll(numbers);
            Console.WriteLine(sb);
        }
    }
}
