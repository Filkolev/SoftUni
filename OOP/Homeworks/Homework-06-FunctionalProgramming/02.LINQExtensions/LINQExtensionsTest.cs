namespace _02.LINQExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LinqExtensionsTest
    {
        public static void Main()
        {
            List<string> testList = new List<string>() { "a", "b", "c", "d", "aa" };

            var filteredByNegation = testList
                .WhereNot(element => element.Length < 2)
                .ToList();
            foreach (var element in filteredByNegation)
            {
                Console.Write("{0} ", element);
            }

            Console.WriteLine();

            var repeated = testList.Repeat(3).ToList();
            foreach (var element in repeated)
            {
                Console.Write("{0} ", element);
            }

            Console.WriteLine();

            var filteredBySuffixes = testList
                .WhereEndsWith(new List<string> { "a", "c" })
                .ToList();
            foreach (var filteredBySuffix in filteredBySuffixes)
            {
                Console.Write("{0} ", filteredBySuffix);
            }

            Console.WriteLine();
        }
    }
}
