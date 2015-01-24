using System;

/* Write an expression that checks if given positive integer number n (n ≤ 100) is prime 
 (i.e. it is divisible without remainder only to itself and 1). */

class PrimeNumberCheck
{
    static void Main()
    {
        Console.Write("Please enter a positive number between 0 and 100: ");
        int n;
        bool isParsed = int.TryParse(Console.ReadLine(), out n);
        
        // If the input isn't valid, ask the user to re-enter
        while (isParsed == false || n < 0 || n > 100)
        {            
            Console.Write("The number you entered is not between 0 and 100! Please enter again: ");
            isParsed = int.TryParse(Console.ReadLine(), out n);
        }

        bool isPrime = true;

        if (n == 1 || n == 0) // 0 and 1 are not prime
        {
            isPrime = false;            
        }

        else
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                }
            }            
        }

        Console.WriteLine();

        if (isPrime)
        {
            Console.WriteLine("The number {0} is prime!", n);
        }

        else
        {
            Console.WriteLine("The number {0} is NOT prime!", n);
        }

        Console.WriteLine();
    }        
}
