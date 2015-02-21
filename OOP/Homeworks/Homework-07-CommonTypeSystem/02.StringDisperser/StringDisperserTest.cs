namespace _02.StringDisperser
{
    using System;

    public class StringDisperserTest
    {
        public static void Main()
        {
            StringDisperser stringDisperser = new StringDisperser("gosho", "pesho", "tanio");

            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");
            }
        }
    }
}
