using System;

namespace _05.BitArray
{
    class BitArrayTest
    {
        static void Main()
        {
            BitArray test = new BitArray(32);
            Console.WriteLine(test[5]);
            test[5] = 1;
            Console.WriteLine(test[5]);
            Console.WriteLine(test);

            // test[32] = 1; // bit array was initialized with 32 elements
            // BitArray large = new BitArray(100001);

            BitArray max = new BitArray(100000);
            max[99999] = 1;
            Console.WriteLine(max);
            Console.WriteLine(max & test);
        }
    }
}
