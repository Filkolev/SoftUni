using System;

/* Write an if-statement that takes two integer variables a and b and exchanges 
their values if the first one is greater than the second one. As a result 
print the values a and b, separated by a space. */

class ExchangeIfGreater
{
    static void Main()
    {
        Console.WriteLine("Enter two numbers, a and b.");
        Console.Write("a = ");
        decimal a = decimal.Parse(Console.ReadLine());
        Console.Write("b = ");
        decimal b = decimal.Parse(Console.ReadLine());

        if (a > b)
        {
            decimal aInitial = a;
            a = b;
            b = aInitial;
        }
            
        Console.Write("\n{0} {1}\n\n", a, b);
    }
}
