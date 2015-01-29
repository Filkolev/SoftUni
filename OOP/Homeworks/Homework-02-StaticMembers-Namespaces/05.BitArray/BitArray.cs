

namespace _05.BitArray
{
    using System;
    using System.Numerics;

    class BitArray
    {
        public const int MaxSize = 100000;
        private int size;
        private bool[] bits;

        public BitArray(int size)
        {
            this.Size = size;
            this.bits = new bool[size];
        }

        public int Size
        {
            get { return this.size; }
            private set
            {
                if (value < 1 || value > MaxSize)
                {
                    throw new ArgumentOutOfRangeException("size", "Size should be in the range [1 ... 100 000].");
                }

                this.size = value;
            }
        }

        public BigInteger Value
        {
            get { return BitArrayToDecimalString(this); }
        }

        public static BitArray operator ^(BitArray arr1, BitArray arr2)
        {
            int max = Math.Max(arr1.Size, arr2.Size);
            int min = Math.Min(arr1.Size, arr2.Size);
            BitArray biggerArray = arr1.Size < arr2.Size ? arr2 : arr1;

            BitArray result = new BitArray(max);

            for (int i = 0; i < min; i++)
            {
                result[i] = arr1[i] ^ arr2[i];
            }

            for (int i = min; i < max; i++)
            {
                result[i] = biggerArray[i] ^ 0;
            }

            return result;
        }

        public static BitArray operator |(BitArray arr1, BitArray arr2)
        {
            int max = Math.Max(arr1.Size, arr2.Size);
            int min = Math.Min(arr1.Size, arr2.Size);
            BitArray biggerArray = arr1.Size < arr2.Size ? arr2 : arr1;

            BitArray result = new BitArray(max);

            for (int i = 0; i < min; i++)
            {
                result[i] = arr1[i] | arr2[i];
            }

            for (int i = min; i < max; i++)
            {
                result[i] = biggerArray[i];
            }

            return result;
        }

        public static BitArray operator &(BitArray arr1, BitArray arr2)
        {
            int max = Math.Max(arr1.Size, arr2.Size);
            int min = Math.Min(arr1.Size, arr2.Size);

            BitArray result = new BitArray(max);

            for (int i = 0; i < min; i++)
            {
                result[i] = arr1[i] & arr2[i];
            }

            return result;
        }

        public static BitArray operator ~(BitArray arr)
        {
            BitArray result = new BitArray(arr.Size);

            for (int i = 0; i < arr.Size; i++)
            {
                result[i] = arr[i] ^ 1;
            }

            return result;
        }

        public int this[int i]
        {
            get
            {
                if (i >= 0 && i < this.Size)
                {
                    return this.bits[i] ? 1 : 0;
                }

                string message = String.Format("Index should be in the range [1 ... {0}]", this.Size - 1);
                throw new IndexOutOfRangeException(message);
            }
            set
            {
                if (i < 0 || i >= this.Size)
                {
                    string message = String.Format("Index should be in the range [1 ... {0}]", this.Size - 1);
                    throw new IndexOutOfRangeException(message);
                }

                if (value != 0 && value != 1)
                {
                    throw new ArgumentException("Value should be either 0 or 1.", "value");
                }

                this.bits[i] = value == 1;
            }
        }

        public static BigInteger BitArrayToDecimalString(BitArray arr)
        {
            BigInteger decimalResult = new BigInteger();

            for (int i = 0; i < arr.Size; i++)
            {
                if (arr[i] != 1)
                {
                    continue;
                }

                BigInteger powerOfTwo = new BigInteger(1);
                for (int j = 0; j < i; j++)
                {
                    powerOfTwo *= 2;
                }

                decimalResult += powerOfTwo;
            }

            return decimalResult;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
