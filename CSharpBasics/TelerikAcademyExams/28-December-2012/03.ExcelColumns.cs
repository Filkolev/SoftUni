using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/275

class ExcelColumns
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());

        int[] numbers = new int[count];
        long result = 0;

        for (int i = 0; i < count; i++)
        {
            char currentLetter = char.Parse(Console.ReadLine());
            numbers[i] = currentLetter - 'A' + 1;
        }

        Array.Reverse(numbers);

        for (int i = 0; i < count; i++)
        {
            result += (long)(numbers[i] * Math.Pow(26, i));
        }

        Console.WriteLine(result);
    }
}
