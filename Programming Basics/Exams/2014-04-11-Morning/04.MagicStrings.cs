using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/38

class MagicStrings
{
    static void Main()
    {
        int diff = int.Parse(Console.ReadLine());

        char[] chars = { 'k', 'n', 'p', 's' };

        bool found = false;

        // Loop through all possible combinations with nested loops
        for (int char1 = 0; char1 < 4; char1++)
        {
            for (int char2 = 0; char2 < 4; char2++)
            {
                for (int char3 = 0; char3 < 4; char3++)
                {
                    for (int char4 = 0; char4 < 4; char4++)
                    {
                        for (int char5 = 0; char5 < 4; char5++)
                        {
                            for (int char6 = 0; char6 < 4; char6++)
                            {
                                for (int char7 = 0; char7 < 4; char7++)
                                {
                                    for (int char8 = 0; char8 < 4; char8++)
                                    {                                        
                                        string left = "" + chars[char1] + chars[char2] + chars[char3] + chars[char4];
                                        string right = "" + chars[char5] + chars[char6] + chars[char7] + chars[char8];

                                        int leftSum = GetWeight(left);
                                        int rightSum = GetWeight(right);                                        

                                        if (Math.Abs(leftSum - rightSum) == diff)
                                        {
                                            Console.WriteLine("{0}{1}", left, right);
                                            found = true;
                                        }   
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("No"); 
        }
    }

    static int GetWeight(string halfString)
    {
        int sum = 0;

        for (int i = 0; i < 4; i++)
        {
            switch (halfString[i])
            {
                case 's':
                    sum += 3;
                    break;
                case 'n':
                    sum += 4;
                    break;
                case 'k':
                    sum += 1;
                    break;
                case 'p':
                    sum += 5;
                    break;
            }
        }

        return sum;
    }
}
