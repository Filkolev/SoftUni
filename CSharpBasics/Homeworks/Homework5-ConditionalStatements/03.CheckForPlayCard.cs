using System;

/* Classical play cards use the following signs to designate the card face: 
 * 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. Write a program that enters a 
 * string and prints “yes” if it is a valid card sign or “no” otherwise. */

class CheckForPlayCard
{
    static void Main()
    {
        Console.Write("Enter input to check if it is a playing card: ");
        string input = Console.ReadLine();
        int numeric;

        int.TryParse(input, out numeric);

        if ((numeric >= 2 && numeric <= 10) 
            || input == "Q" 
            || input == "J" 
            || input == "K" 
            || input == "A")
        {
            Console.WriteLine("Result: yes"); 
        }

        else
        {
            Console.WriteLine("Result: no");
        }
    }
}
