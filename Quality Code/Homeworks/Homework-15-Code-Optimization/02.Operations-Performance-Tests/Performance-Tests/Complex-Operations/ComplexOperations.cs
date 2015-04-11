namespace Complex_Operations
{
    using System;
    using System.Diagnostics;

    public class ComplexOperations
    {
        private const int NumberOfOperationsToPerform = 1000000;

        private const float FloatValue = 1.1f;
        private const double DoubleValue = 1.1;
        private const decimal DecimalValue = 1.1m;

        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("Square Root");

            stopwatch.Start();
            PerformSquareRootOnFloatValue();
            stopwatch.Stop();
            Console.WriteLine("Float: " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformSquareRootOnDoubleValue();
            stopwatch.Stop();
            Console.WriteLine("Double: " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformSquareRootOnDecimalValue();
            stopwatch.Stop();
            Console.WriteLine("Decimal: " + stopwatch.Elapsed);
            stopwatch.Reset();

            Console.WriteLine();
            Console.WriteLine("Natural Logarithm");

            stopwatch.Start();
            PerformNaturalLogarithmOnFloatValue();
            stopwatch.Stop();
            Console.WriteLine("Float: " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformNaturalLogarithmOnDoubleValue();
            stopwatch.Stop();
            Console.WriteLine("Double: " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformNaturalLogarithmOnDecimalValue();
            stopwatch.Stop();
            Console.WriteLine("Decimal: " + stopwatch.Elapsed);
            stopwatch.Reset();

            Console.WriteLine();
            Console.WriteLine("Sine");

            stopwatch.Start();
            PerformSineOnFloatValue();
            stopwatch.Stop();
            Console.WriteLine("Float: " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformSineOnDoubleValue();
            stopwatch.Stop();
            Console.WriteLine("Double: " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformSineOnDecimalValue();
            stopwatch.Stop();
            Console.WriteLine("Decimal: " + stopwatch.Elapsed);
            stopwatch.Reset();
        }

        private static void PerformSquareRootOnFloatValue()
        {
            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                Math.Sqrt(FloatValue);
            }
        }

        private static void PerformSquareRootOnDoubleValue()
        {
            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                Math.Sqrt(DoubleValue);
            }
        }

        private static void PerformSquareRootOnDecimalValue()
        {
            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                Math.Sqrt((double)DecimalValue);
            }
        }

        private static void PerformNaturalLogarithmOnFloatValue()
        {
            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                Math.Log(FloatValue, Math.E);
            }
        }

        private static void PerformNaturalLogarithmOnDoubleValue()
        {
            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                Math.Log(DoubleValue, Math.E);
            }
        }

        private static void PerformNaturalLogarithmOnDecimalValue()
        {
            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                Math.Log((double)DecimalValue, Math.E);
            }
        }

        private static void PerformSineOnFloatValue()
        {
            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                Math.Sin(FloatValue);
            }
        }

        private static void PerformSineOnDoubleValue()
        {
            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                Math.Sin(DoubleValue);
            }
        }

        private static void PerformSineOnDecimalValue()
        {
            for (int i = 0; i < NumberOfOperationsToPerform; i++)
            {
                Math.Sin((double)DecimalValue);
            }
        }
    }
}
