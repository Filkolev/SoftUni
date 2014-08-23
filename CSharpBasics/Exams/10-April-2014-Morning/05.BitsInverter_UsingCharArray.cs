using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());

        int position = 0;

        for (int i = 0; i < n; i++)
        {
            int currentNum = int.Parse(Console.ReadLine());
            char[] binaryNumToArray = Convert.ToString(currentNum, 2).PadLeft(8, '0').ToCharArray();           

            for (int index = 0; index < 8; index++)
            {
                if ((index + position) % step == 0 || step == 1)
                {
                    if (binaryNumToArray[index] == '0')
                    {
                        binaryNumToArray[index] = '1';
                    }

                    else
                    {
                        binaryNumToArray[index] = '0';
                    }
                }
            }

            position += 8;

            StringBuilder arrayToBinary = new StringBuilder();

            for (int j = 0; j < 8; j++)
            {
                arrayToBinary.Append(binaryNumToArray[j]);
            }            

            string binaryNum = arrayToBinary.ToString();

            Console.WriteLine(Convert.ToInt32(binaryNum, 2));
        }
    }
}
