using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/90

class MagicCarNumbers
{
    static void Main()
    {
        int magicWeight = int.Parse(Console.ReadLine());

        int countOfMagic = 0;

        char[] letters = { 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X' };

        string carNumber = null;

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int m = 0; m < letters.Length; m++)
                {
                    for (int n = 0; n < letters.Length; n++)
                    {
                        if (i == j)
                        {
                            carNumber = "CA" + i + i + i + i + letters[m] + letters[n];

                            countOfMagic += checkNumber(magicWeight, countOfMagic, carNumber);
                        }

                        else
                        {
                            carNumber = "CA" + i + j + j + j + letters[m] + letters[n];
                            countOfMagic += checkNumber(magicWeight, countOfMagic, carNumber);

                            carNumber = "CA" + i + i + i + j + letters[m] + letters[n];
                            countOfMagic += checkNumber(magicWeight, countOfMagic, carNumber);                               

                            carNumber = "CA" + i + i + j + j + letters[m] + letters[n];
                            countOfMagic += checkNumber(magicWeight, countOfMagic, carNumber);
                           
                            carNumber = "CA" + i + j + i + j + letters[m] + letters[n];
                            countOfMagic += checkNumber(magicWeight, countOfMagic, carNumber);                               

                            carNumber = "CA" + i + j + j + i + letters[m] + letters[n];
                            countOfMagic += checkNumber(magicWeight, countOfMagic, carNumber);                                
                        }  
                    }
                }              
            }
        }

        Console.WriteLine(countOfMagic);
    }

    private static int checkNumber(int magicWeight, int countOfMagic, string carNumber)
    {
        if (calculateWeight(carNumber) == magicWeight)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }


    public static int calculateWeight(string carNumber)
    {
        int weight = 0;

        for (int i = 0; i < 8; i++)
        {          
                if (carNumber[i] >= 'A' && carNumber[i] <= 'Z')
	            {
		             weight += (carNumber[i] - 'A' + 1) * 10;
	            }

                else
                {
                    weight += (carNumber[i] - '0');
                }         
        }

        return weight;
    }
}
