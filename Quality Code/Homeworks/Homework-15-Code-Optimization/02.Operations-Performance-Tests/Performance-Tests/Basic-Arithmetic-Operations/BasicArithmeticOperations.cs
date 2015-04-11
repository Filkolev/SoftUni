namespace Basic_Arithmetic_Operations
{
    using System;
    using System.Diagnostics;

    public class BasicArithmeticOperations
    {
        private const int NumberOfOperationsToPerform = 1000000;

        private const int FirstIntNumber = 1;
        private const int SecondIntNumber = 5;

        private const long FirstLongNumber = 1L;
        private const long SecondLongNumber = 100000000000;

        private const float FirstFloatNumber = 1.1f;
        private const float SecondFloatNumber = 3.14f;

        private const double FirstDoubleNumber = 1.1;
        private const double SecondDoubleNumber = 3.14;

        private const decimal FirstDecimalNumber = 1.1m;
        private const decimal SecondDecimalNumber = 3.14m;

        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Addition");

            // Test adding int values
            stopwatch.Start();
            AddIntValues();
            stopwatch.Stop();
            Console.WriteLine("Int: {0}", stopwatch.Elapsed);

            stopwatch.Reset();

            // Test adding long values
            stopwatch.Start();
            AddLongValues();
            stopwatch.Stop();
            Console.WriteLine("Long: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test adding float values
            stopwatch.Start();
            AddFloatValues();
            stopwatch.Stop();
            Console.WriteLine("Float: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test adding double values
            stopwatch.Start();
            AddDoubleValues();
            stopwatch.Stop();
            Console.WriteLine("Double: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test adding decimal values
            stopwatch.Start();
            AddDecimalValues();
            stopwatch.Stop();
            Console.WriteLine("Decimal: " + stopwatch.Elapsed);

            stopwatch.Reset();

            Console.WriteLine();
            Console.WriteLine("Subtraction");

            // Test subtracting int values
            stopwatch.Start();
            SubtractIntValues();
            stopwatch.Stop();
            Console.WriteLine("Int: {0,10}", stopwatch.Elapsed);

            stopwatch.Reset();

            // Test subtracting long values
            stopwatch.Start();
            SubtractLongValues();
            stopwatch.Stop();
            Console.WriteLine("Long: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test subtracting float values
            stopwatch.Start();
            SubtractFloatValues();
            stopwatch.Stop();
            Console.WriteLine("Float: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test subtracting double values
            stopwatch.Start();
            SubtractDoubleValues();
            stopwatch.Stop();
            Console.WriteLine("Double: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test subtracting decimal values
            stopwatch.Start();
            SubtractDecimalValues();
            stopwatch.Stop();
            Console.WriteLine("Decimal: " + stopwatch.Elapsed);

            stopwatch.Reset();

            Console.WriteLine();
            Console.WriteLine("Incrementation");

            // Test incrementing int values
            stopwatch.Start();
            IncrementIntValue();
            stopwatch.Stop();
            Console.WriteLine("Int: {0,10}", stopwatch.Elapsed);

            stopwatch.Reset();

            // Test incrementing long values
            stopwatch.Start();
            IncrementLongValue();
            stopwatch.Stop();
            Console.WriteLine("Long: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test incrementing float values
            stopwatch.Start();
            IncrementFloatValue();
            stopwatch.Stop();
            Console.WriteLine("Float: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test incrementing double values
            stopwatch.Start();
            IncrementDoubleValue();
            stopwatch.Stop();
            Console.WriteLine("Double: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test incrementing decimal values
            stopwatch.Start();
            IncrementDecimalValue();
            stopwatch.Stop();
            Console.WriteLine("Decimal: " + stopwatch.Elapsed);

            stopwatch.Reset();

            Console.WriteLine();
            Console.WriteLine("Multiplication");

            // Test multiplying int values
            stopwatch.Start();
            MultiplyIntValues();
            stopwatch.Stop();
            Console.WriteLine("Int: {0,10}", stopwatch.Elapsed);

            stopwatch.Reset();

            // Test multiplying long values
            stopwatch.Start();
            MultiplyLongValues();
            stopwatch.Stop();
            Console.WriteLine("Long: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test multiplying float values
            stopwatch.Start();
            MultiplyFloatValues();
            stopwatch.Stop();
            Console.WriteLine("Float: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test multiplying double values
            stopwatch.Start();
            MultiplyDoubleValues();
            stopwatch.Stop();
            Console.WriteLine("Double: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test multiplying decimal values
            stopwatch.Start();
            MultiplyDecimalValues();
            stopwatch.Stop();
            Console.WriteLine("Decimal: " + stopwatch.Elapsed);

            stopwatch.Reset();

            Console.WriteLine();
            Console.WriteLine("Division");

            // Test dividing int values
            stopwatch.Start();
            DivideIntValues();
            stopwatch.Stop();
            Console.WriteLine("Int: {0,10}", stopwatch.Elapsed);

            stopwatch.Reset();

            // Test dividing long values
            stopwatch.Start();
            DivideLongValues();
            stopwatch.Stop();
            Console.WriteLine("Long: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test dividing float values
            stopwatch.Start();
            DivideFloatValues();
            stopwatch.Stop();
            Console.WriteLine("Float: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test dividing double values
            stopwatch.Start();
            DivideDoubleValues();
            stopwatch.Stop();
            Console.WriteLine("Double: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test dividing decimal values
            stopwatch.Start();
            DivideDecimalValues();
            stopwatch.Stop();
            Console.WriteLine("Decimal: " + stopwatch.Elapsed);

            stopwatch.Reset();
        }

        private static void AddIntValues()
        {
            int result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstIntNumber + SecondIntNumber;
            }
        }

        private static void AddLongValues()
        {
            long result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstLongNumber + SecondLongNumber;
            }
        }

        private static void AddFloatValues()
        {
            float result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstFloatNumber + SecondFloatNumber;
            }
        }

        private static void AddDoubleValues()
        {
            double result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstDoubleNumber + SecondDoubleNumber;
            }
        }

        private static void AddDecimalValues()
        {
            decimal result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstDecimalNumber + SecondDecimalNumber;
            }
        }

        private static void SubtractIntValues()
        {
            int result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstIntNumber - SecondIntNumber;
            }
        }

        private static void SubtractLongValues()
        {
            long result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstLongNumber - SecondLongNumber;
            }
        }

        private static void SubtractFloatValues()
        {
            float result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstFloatNumber - SecondFloatNumber;
            }
        }

        private static void SubtractDoubleValues()
        {
            double result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstDoubleNumber - SecondDoubleNumber;
            }
        }

        private static void SubtractDecimalValues()
        {
            decimal result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstDecimalNumber - SecondDecimalNumber;
            }
        }

        private static void IncrementIntValue()
        {
            int result = 0;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result++;
            }
        }

        private static void IncrementLongValue()
        {
            long result = 0L;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result++;
            }
        }

        private static void IncrementFloatValue()
        {
            float result = 0.1f;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result++;
            }
        }

        private static void IncrementDoubleValue()
        {
            double result = 0.1;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result++;
            }
        }

        private static void IncrementDecimalValue()
        {
            decimal result = 0.1m;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result++;
            }
        }

        private static void MultiplyIntValues()
        {
            int result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstIntNumber * SecondIntNumber;
            }
        }

        private static void MultiplyLongValues()
        {
            long result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstLongNumber * SecondLongNumber;
            }
        }

        private static void MultiplyFloatValues()
        {
            float result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstFloatNumber * SecondFloatNumber;
            }
        }

        private static void MultiplyDoubleValues()
        {
            double result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstDoubleNumber * SecondDoubleNumber;
            }
        }

        private static void MultiplyDecimalValues()
        {
            decimal result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstDecimalNumber * SecondDecimalNumber;
            }
        }

        private static void DivideIntValues()
        {
            int result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstIntNumber / SecondIntNumber;
            }
        }

        private static void DivideLongValues()
        {
            long result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstLongNumber / SecondLongNumber;
            }
        }

        private static void DivideFloatValues()
        {
            float result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstFloatNumber / SecondFloatNumber;
            }
        }

        private static void DivideDoubleValues()
        {
            double result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstDoubleNumber / SecondDoubleNumber;
            }
        }

        private static void DivideDecimalValues()
        {
            decimal result;

            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                result = FirstDecimalNumber / SecondDecimalNumber;
            }
        }
    }
}
