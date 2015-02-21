namespace _03.GenericList
{
    using System;

    class GenericListTest
    {
        static void Main()
        {
            GenericList<int> integerList = new GenericList<int>();
            Console.WriteLine(integerList.Capacity); // 16
            Console.WriteLine(integerList.Count); // 0

            integerList.Add(1);
            integerList.Add(2);
            integerList.InsertAt(1, 3);
            Console.WriteLine(integerList.Capacity); // 16
            Console.WriteLine(integerList.Count); // 3
            Console.WriteLine(integerList); // {1, 3, 2}
            Console.WriteLine(integerList.IndexOf(1)); // 0
            Console.WriteLine(integerList.Exists(0)); // False
            Console.WriteLine(integerList.Exists(2)); // True

            integerList.RemoveAt(0);
            Console.WriteLine(integerList); // {3, 2}
            Console.WriteLine(integerList.IndexOf(1)); // -1
            Console.WriteLine(GenericList<int>.Min(integerList)); // 2
            Console.WriteLine(GenericList<int>.Max(integerList)); // 3

            integerList.InsertAt(12, 7);
            Console.WriteLine(integerList.Count); // 13
            Console.WriteLine(integerList); // {3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7}

            System.Reflection.MemberInfo info = typeof(GenericList<>);
            foreach (object attribute in info.GetCustomAttributes(false))
            {
                Console.WriteLine(attribute);
            }
        }
    }
}
