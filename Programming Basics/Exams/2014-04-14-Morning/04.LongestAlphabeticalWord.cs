using System;
using System.Text;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/80

class LongestAlphabeticalWord
{
    static void Main()
    {
        string word = Console.ReadLine();
        int size = int.Parse(Console.ReadLine());

        char[,] block = new char[size, size];

        int startPosition = 0;

        // Fill a matrix with the word
        for (int row = 0; row < size; row++)
        {
            for (int column = 0; column < size; column++)
            {
                block[row, column] = word[startPosition];
                startPosition++;

                if (startPosition == word.Length)
                {
                    startPosition = 0; 
                }
            }
        }

        string longestWord = "";
        StringBuilder currentLongestWord = new StringBuilder();

        // Go in each direction until a previous element or the edge of the matrix is reached
        // After reaching the end in a direction, check the current word if it's the longest
        for (int row = 0; row < size; row++)
        {
            for (int column = 0; column < size; column++)
            {                
                currentLongestWord.Append(block[row, column]);

                // Go left
                int toLeft = column - 1;
                while (toLeft >= 0)
                {
                    if (block[row, toLeft] > block[row, toLeft + 1])
                    {
                        currentLongestWord.Append(block[row, toLeft]);
                        toLeft--;
                    }

                    else
                    {
                        break;
                    }
                }               

                longestWord = CheckWord(longestWord, currentLongestWord);

                currentLongestWord.Clear();
                currentLongestWord.Append(block[row, column]);

                // Go right
                int toRight = column + 1;
                while (toRight < size)
                {
                    if (block[row, toRight] > block[row, toRight - 1])
                    {
                        currentLongestWord.Append(block[row, toRight]);
                        toRight++;
                    }

                    else
                    {
                        break;
                    }
                }

                longestWord = CheckWord(longestWord, currentLongestWord);

                currentLongestWord.Clear();
                currentLongestWord.Append(block[row, column]);

                // Go up
                int toTop = row - 1;
                while (toTop >= 0)
                {
                    if (block[toTop, column] > block[toTop + 1, column])
                    {
                        currentLongestWord.Append(block[toTop, column]);
                        toTop--;
                    }

                    else
                    {
                        break;
                    }
                }

                longestWord = CheckWord(longestWord, currentLongestWord);

                currentLongestWord.Clear();
                currentLongestWord.Append(block[row, column]);

                // Go down
                int toBottom = row + 1;
                while (toBottom < size)
                {
                    if (block[toBottom, column] > block[toBottom - 1, column])
                    {
                        currentLongestWord.Append(block[toBottom, column]);
                        toBottom++;
                    }

                    else
                    {
                        break;
                    }
                }

                longestWord = CheckWord(longestWord, currentLongestWord);
                currentLongestWord.Clear();

            }
        }

        Console.WriteLine(longestWord);
    }

    private static string CheckWord(string longestWord, StringBuilder currentLongestWord)
    {
        if (currentLongestWord.Length > longestWord.Length)
        {
            longestWord = currentLongestWord.ToString();
        }

        else if (currentLongestWord.Length == longestWord.Length)
        {
            for (int i = 0; i < currentLongestWord.Length; i++)
            {
                if (currentLongestWord[i] < longestWord[i])
                {
                    longestWord = currentLongestWord.ToString();
                    break;
                }

                else if (currentLongestWord[i] > longestWord[i])
                {
                    break;
                }
            }
        }

        return longestWord;
    }
}
