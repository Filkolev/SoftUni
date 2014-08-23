using System;

/* Write a program that generates and prints all possible cards from a standard deck of 
 52 cards (without the jokers). The cards should be printed using the classical notation 
 (like 5♠, A♥, 9♣ and K♦). The card faces should start from 2 to A. Print each card face 
 in its four possible suits: clubs, diamonds, hearts and spades. Use 2 nested for-loops and 
 a switch-case statement. */

class PrintDeckOf52Cards
{
    static void Main()
    {
        char spade = '\u2660';
        char heart = '\u2665';
        char diamond = '\u2666';
        char club = '\u2663';

        char[] suit = { club, diamond, heart, spade };
        string[] face = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        for (int j = 0; j < face.Length; j++)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write("{0,3}{1} ", face[j], suit[i]);
            }
            Console.WriteLine();            
        }

        Console.WriteLine();   
    }
}
