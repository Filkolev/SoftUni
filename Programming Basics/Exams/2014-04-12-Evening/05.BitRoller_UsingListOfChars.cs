using System;
using System.Collections.Generic;
using System.Text;

class BitRoller
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        int fixedBitInitialPosition = int.Parse(Console.ReadLine());
        int rolls = int.Parse(Console.ReadLine());

        string binary = Convert.ToString(number, 2).PadLeft(19, '0');
        char[] binaryNumToArray = binary.ToCharArray();

        List<char> bitsList = new List<char>(binaryNumToArray.Length);

        for (int i = 0; i < binaryNumToArray.Length; i++)
        {
            bitsList.Add(binaryNumToArray[i]);
        }

        char fixedChar = bitsList[18 - fixedBitInitialPosition];
        bitsList.RemoveAt(18 - fixedBitInitialPosition);

        for (int i = 0; i < rolls; i++)
        {
            char currentChar = bitsList[bitsList.Count - 1];
            bitsList.RemoveAt(bitsList.Count - 1);
            bitsList.Insert(0, currentChar);
        }

        bitsList.Insert(18 - fixedBitInitialPosition, fixedChar);

        StringBuilder arrayToBinary = new StringBuilder();

        for (int j = 0; j < bitsList.Count; j++)
        {
            arrayToBinary.Append(bitsList[j]);
        }

        string binaryNum = arrayToBinary.ToString();

        Console.WriteLine(Convert.ToInt32(binaryNum, 2));

    }
}
