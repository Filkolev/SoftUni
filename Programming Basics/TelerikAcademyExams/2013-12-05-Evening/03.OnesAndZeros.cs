using System;
using System.Text;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/498

class OnesAndZeros
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        StringBuilder firstRow = new StringBuilder();
        StringBuilder secondRow = new StringBuilder();
        StringBuilder thirdRow = new StringBuilder();
        StringBuilder fourthRow = new StringBuilder();
        StringBuilder fifthRow = new StringBuilder();

        int currentBit = (number >> 15) & 1;
        switch (currentBit)
        {
            case 1:
                firstRow.Append(".#.");
                secondRow.Append("##.");
                thirdRow.Append(".#.");
                fourthRow.Append(".#.");
                fifthRow.Append("###");
                break;
            case 0:
                firstRow.Append("###");
                secondRow.Append("#.#");
                thirdRow.Append("#.#");
                fourthRow.Append("#.#");
                fifthRow.Append("###");
                break;
        }

        for (int i = 14; i >= 0; i--)
        {
            currentBit = (number >> i) & 1;
            switch (currentBit)
            {
                case 1:
                    firstRow.Append("..#.");
                    secondRow.Append(".##.");
                    thirdRow.Append("..#.");
                    fourthRow.Append( "..#.");
                    fifthRow.Append(".###");
                    break;
                case 0:
                    firstRow.Append(".###");
                    secondRow.Append(".#.#");
                    thirdRow.Append(".#.#");
                    fourthRow.Append(".#.#");
                    fifthRow.Append(".###");
                    break;
            }
        }

        Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}", firstRow, secondRow, thirdRow, fourthRow, fifthRow);
    }
}
