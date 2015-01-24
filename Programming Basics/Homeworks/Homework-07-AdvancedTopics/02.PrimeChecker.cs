using System;

// Write a Boolean method IsPrime(n) that check whether a given integer number n is prime.

class PrimeChecker
{
    static void Main()
    {
        Console.Write("Enter an integer number n to check if it's prime (divisible without remainder only to itself and 1).");
        Console.Write("\nn = ");

        ulong n;
        while (!ulong.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("Invalid input, please enter a positive number.\nn = ");
        }

        Console.Write("\nThe number {0} is ", n);
        Console.Write(IsPrime(n) ? "prime.\n\n" : "not prime.\n\n");
    }

    public static bool IsPrime(ulong number)
    {
        bool prime = true;

        if (number < 2)
        {
            prime = false;
        }

        for (ulong i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                prime = false;
            }
        }

        return prime;
    }
}
