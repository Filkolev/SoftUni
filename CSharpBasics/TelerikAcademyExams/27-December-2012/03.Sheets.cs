using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/276

class Sheets
{
    static void Main()
    {
        int piecesToMake = int.Parse(Console.ReadLine());

        int[] sheetSizes = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        bool[] used = new bool[sheetSizes.Length];

        for (int i = 0; i < sheetSizes.Length; i++)
        {
            int possiblePieces = (int)Math.Pow(2, sheetSizes[i]);

            if (piecesToMake >= possiblePieces)
            {
                used[i] = true;
                piecesToMake -= possiblePieces;
            }

            if (!used[i])
            {
                Console.WriteLine("A{0}", i);
            }
        }
    }
}
