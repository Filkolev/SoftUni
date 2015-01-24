using System;

/* Declare two integer variables a and b and assign them with 5 and 10 and after that exchange 
 their values by using some programming logic. Print the variable values before and after the exchange. */

class ExchangeVariableValues
{
    static void Main()
    {
        int a = 5;
        int b = 10;
        
        int bInitial = b; 
        
        Console.WriteLine("The initial value of a is: " + a);
        Console.WriteLine("The initial value of b is: " + b);
        
        b = a;        
        a = bInitial; 

        Console.WriteLine("The value of a after the exchange is: " + a);
        Console.WriteLine("The value of b after the exchange is: " + b);
    }
}
