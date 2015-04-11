namespace Sorting_Algorithms
{
    using System;
    using System.Diagnostics;

    public class SortingAlgorithms
    {
        private static readonly int[] IntNumbersQuick = { 3, 44, 38, 5, 47, 15, 36, 26, 27, 2, 46, 4, 19, 50, 48 };
        private static readonly int[] IntNumbersSelection = { 3, 44, 38, 5, 47, 15, 36, 26, 27, 2, 46, 4, 19, 50, 48 };
        private static readonly int[] IntNumbersInsertion = { 3, 44, 38, 5, 47, 15, 36, 26, 27, 2, 46, 4, 19, 50, 48 };

        private static readonly double[] DoubleNumbersQuick = { 3.1, 44.1, 38.1, 5.1, 47.1, 15.1, 36.1, 26.1, 27.1, 2.1, 46.1, 4.1, 19.1, 50.1, 48.1 };
        private static readonly double[] DoubleNumbersSelection = { 3.1, 44.1, 38.1, 5.1, 47.1, 15.1, 36.1, 26.1, 27.1, 2.1, 46.1, 4.1, 19.1, 50.1, 48.1 };
        private static readonly double[] DoubleNumbersInsertion = { 3.1, 44.1, 38.1, 5.1, 47.1, 15.1, 36.1, 26.1, 27.1, 2.1, 46.1, 4.1, 19.1, 50.1, 48.1 };

        private static readonly string[] StringsQuick = { "3", "44", "38", "5", "47", "15", "36", "26", "27", "2", "46", "4", "19", "50", "48" };
        private static readonly string[] StringsSelection = { "3", "44", "38", "5", "47", "15", "36", "26", "27", "2", "46", "4", "19", "50", "48" };
        private static readonly string[] StringsInsertion = { "3", "44", "38", "5", "47", "15", "36", "26", "27", "2", "46", "4", "19", "50", "48" };

        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            PerformQuickSort(IntNumbersQuick, 0, IntNumbersQuick.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Quick Sort (Random Int Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformInsertionSort(IntNumbersInsertion);
            stopwatch.Stop();
            Console.WriteLine("Insertion Sort (Random Int Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformSelectionSort(IntNumbersSelection);
            stopwatch.Stop();
            Console.WriteLine("Selection Sort (Random Int Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformQuickSort(IntNumbersQuick, 0, IntNumbersQuick.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Quick Sort (Sorted Int Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformInsertionSort(IntNumbersInsertion);
            stopwatch.Stop();
            Console.WriteLine("Insertion Sort (Sorted Int Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformSelectionSort(IntNumbersSelection);
            stopwatch.Stop();
            Console.WriteLine("Selection Sort (Sorted Int Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            Array.Reverse(IntNumbersQuick);
            Array.Reverse(IntNumbersInsertion);
            Array.Reverse(IntNumbersSelection);

            stopwatch.Start();
            PerformQuickSort(IntNumbersQuick, 0, IntNumbersQuick.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Quick Sort (Reversed Int Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformInsertionSort(IntNumbersInsertion);
            stopwatch.Stop();
            Console.WriteLine("Insertion Sort (Reversed Int Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformSelectionSort(IntNumbersSelection);
            stopwatch.Stop();
            Console.WriteLine("Selection Sort (Reversed Int Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformQuickSort(DoubleNumbersQuick, 0, DoubleNumbersQuick.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Quick Sort (Random Double Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformInsertionSort(DoubleNumbersInsertion);
            stopwatch.Stop();
            Console.WriteLine("Insertion Sort (Random Double Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformSelectionSort(DoubleNumbersSelection);
            stopwatch.Stop();
            Console.WriteLine("Selection Sort (Random Double Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformQuickSort(DoubleNumbersQuick, 0, IntNumbersQuick.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Quick Sort (Sorted Double Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformInsertionSort(DoubleNumbersInsertion);
            stopwatch.Stop();
            Console.WriteLine("Insertion Sort (Sorted Double Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformSelectionSort(DoubleNumbersSelection);
            stopwatch.Stop();
            Console.WriteLine("Selection Sort (Sorted Double Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            Array.Reverse(DoubleNumbersQuick);
            Array.Reverse(DoubleNumbersInsertion);
            Array.Reverse(DoubleNumbersSelection);

            stopwatch.Start();
            PerformQuickSort(DoubleNumbersQuick, 0, IntNumbersQuick.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Quick Sort (Reversed Double Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformInsertionSort(DoubleNumbersInsertion);
            stopwatch.Stop();
            Console.WriteLine("Insertion Sort (Reversed Double Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformSelectionSort(DoubleNumbersSelection);
            stopwatch.Stop();
            Console.WriteLine("Selection Sort (Reversed Double Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformQuickSort(StringsQuick, 0, StringsQuick.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Quick Sort (Random String Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformInsertionSort(StringsInsertion);
            stopwatch.Stop();
            Console.WriteLine("Insertion Sort (Random String Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformSelectionSort(StringsSelection);
            stopwatch.Stop();
            Console.WriteLine("Selection Sort (Random String Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformQuickSort(StringsQuick, 0, StringsQuick.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Quick Sort (Sorted String Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformInsertionSort(StringsInsertion);
            stopwatch.Stop();
            Console.WriteLine("Insertion Sort (Sorted String Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformSelectionSort(StringsSelection);
            stopwatch.Stop();
            Console.WriteLine("Selection Sort (Sorted String Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            Array.Reverse(StringsQuick);
            Array.Reverse(StringsInsertion);
            Array.Reverse(StringsSelection);

            stopwatch.Start();
            PerformQuickSort(StringsQuick, 0, StringsQuick.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Quick Sort (Reversed String Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformInsertionSort(StringsInsertion);
            stopwatch.Stop();
            Console.WriteLine("Insertion Sort (Reversed String Values): " + stopwatch.Elapsed);
            stopwatch.Reset();

            stopwatch.Start();
            PerformInsertionSort(StringsSelection);
            stopwatch.Stop();
            Console.WriteLine("Insertion Sort (Reversed String Values): " + stopwatch.Elapsed);
            stopwatch.Reset();
        }

        private static void PerformInsertionSort<T>(T[] inputArray) where T : IComparable
        {
            int j;
            T temp;
            
            for (int i = 1; i < inputArray.Length; i++)
            {
                temp = inputArray[i];
                j = i - 1;
              
                for (; j >= 0 && temp.CompareTo(inputArray[j]) == -1; j--)
                {
                    inputArray[j + 1] = inputArray[j];
                    inputArray[j] = temp;
                }
            }
        }

        private static void PerformSelectionSort<T>(T[] inputArray) where T : IComparable
        {
            int maxIndex;
            T temp;

            for (int i = inputArray.Length - 1; i > 0; i--)
            {
                maxIndex = 0;
               
                for (int j = 1; j <= i; j++)
                {
                    if (inputArray[j].CompareTo(inputArray[maxIndex]) == 1)
                    {
                        maxIndex = j;
                    }
                }
                
                temp = inputArray[maxIndex];
                inputArray[maxIndex] = inputArray[i];
                inputArray[i] = temp;
            }
        }

        private static void PerformQuickSort<T>(T[] inputArray, int start, int end) where T : IComparable
        {
            if (start < end)
            {
                int pivotIndex = Partition(inputArray, start, end);
                PerformQuickSort(inputArray, start, pivotIndex - 1);
                PerformQuickSort(inputArray, pivotIndex + 1, end);
            }
        }

        private static int Partition<T>(T[] arr, int start, int end) where T : IComparable
        {
            int pivot = end;
            int i = start;
            int j = end;
            T temp;

            while (i < j)
            {
                while (i < end && arr[i].CompareTo(arr[pivot]) == -1)
                {
                    i++;
                }

                while (j > start && arr[j].CompareTo(arr[pivot]) == 1)
                {
                    j--;
                }

                if (i < j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[pivot];
            arr[pivot] = arr[j];
            arr[j] = temp;

            return j;
        }
    }
}
