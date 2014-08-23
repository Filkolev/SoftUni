using System;

/* Write a program that, depending on the user’s choice, inputs an int, 
  double or string variable. If the variable is int or double, the program 
  increases it by one. If the variable is a string, the program appends "*" 
  at the end. Print the result at the console. Use switch statement. */

class PlayWithIntDoubleAndString
{
    static void Main()
    {
        Console.WriteLine("Please choose a type:\n1 --> int\n2 --> double\n3 --> string");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1": 
                Console.Write("\nPlease enter an int: ");
                int usersInt = int.Parse(Console.ReadLine());
                Console.WriteLine("Result: {0}", usersInt + 1);
                break;
            case "2": 
                Console.Write("\nPlease enter a double: ");
                double usersDouble = double.Parse(Console.ReadLine());
                Console.WriteLine("Result: {0}", usersDouble + 1);
                break;
            case "3": 
                Console.Write("\nPlease enter a string: ");
                string usersString = Console.ReadLine();
                Console.WriteLine("Result: {0}*", usersString);
                break;
            default: Console.WriteLine("\nInvalid input!");
                break;
        }

        Console.WriteLine();
    }    
}
