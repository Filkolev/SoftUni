using System;

// Write a program that converts a number in the range [0…999] 
// to words, corresponding to the English pronunciation. 

class NumberAsWord
{
    static void Main()
    {
        // I use a loop to print them all and make sure everything works correctly
        // It can easily be replaced with user input
        Console.BufferHeight = 1001;

        for (int i = 0; i < 1000; i++)
        //string input = Console.ReadLine();
        //int number = int.Parse(input);
        {
            int number = i;

            if (number == 0)
            {
                Console.WriteLine("zero"); // special case
                
            }

            int tens = (number / 10) % 10; 
            int hundreds = number / 100;

            int ones;
            if (tens == 1)
            {
                ones = number % 100; // these are the numbers between 10 and 19
            }

            else
            {
                ones = number % 10;
            }

            switch (hundreds)
            {
                case 1: Console.Write("one hundred");
                    break;
                case 2: Console.Write("two hundred");
                    break;
                case 3: Console.Write("three hundred");
                    break;
                case 4: Console.Write("four hundred");
                    break;
                case 5: Console.Write("five hundred");
                    break;
                case 6: Console.Write("six hundred");
                    break;
                case 7: Console.Write("seven hundred");
                    break;
                case 8: Console.Write("eight hundred");
                    break;
                case 9: Console.Write("nine hundred");
                    break;
            }

            if (hundreds > 0 && (tens != 0 || ones != 0))
            {
                Console.Write(" and "); // add only if the number is not a round hundred
            }
            else if (hundreds > 0)
            {
                Console.WriteLine(); // if it's round hundred move on to the next line
            }

            switch (tens)
            {
                case 2: Console.Write("twenty");
                    break;
                case 3: Console.Write("thirty");
                    break;
                case 4: Console.Write("forty");
                    break;
                case 5: Console.Write("fifty");
                    break;
                case 6: Console.Write("sixty");
                    break;
                case 7: Console.Write("seventy");
                    break;
                case 8: Console.Write("eighty");
                    break;
                case 9: Console.Write("ninety");
                    break;
            }

            if (tens > 1 && ones != 0)
            {
                Console.Write("-"); // add hyphen for numbers like forty-five
            }
            else if (tens > 1 && ones == 0)
            {
                Console.WriteLine(); // if it's a round ten move on
            }

            switch (ones)
            {
                case 1: Console.WriteLine("one");
                    break;
                case 2: Console.WriteLine("two");
                    break;
                case 3: Console.WriteLine("three");
                    break;
                case 4: Console.WriteLine("four");
                    break;
                case 5: Console.WriteLine("five");
                    break;
                case 6: Console.WriteLine("six");
                    break;
                case 7: Console.WriteLine("seven");
                    break;
                case 8: Console.WriteLine("eight");
                    break;
                case 9: Console.WriteLine("nine");
                    break;
                case 10: Console.WriteLine("ten");
                    break;
                case 11: Console.WriteLine("eleven");
                    break;
                case 12: Console.WriteLine("twelve");
                    break;
                case 13: Console.WriteLine("thirteen");
                    break;
                case 14: Console.WriteLine("fourteen");
                    break;
                case 15: Console.WriteLine("fifteen");
                    break;
                case 16: Console.WriteLine("sixteen");
                    break;
                case 17: Console.WriteLine("seventeen");
                    break;
                case 18: Console.WriteLine("eighteen");
                    break;
                case 19: Console.WriteLine("nineteen");
                    break;
            }
        }
    }
}
