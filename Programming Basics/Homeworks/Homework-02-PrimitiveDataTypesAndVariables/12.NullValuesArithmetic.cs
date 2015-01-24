using System;

/* Create a program that assigns null values to an integer and to a double variable. Try to print these 
 variables at the console. Try to add some number or the null literal to these variables and print the result. */

class NullValuesArithmetic
{
    static void Main()
    {
        int? nullInt = null;
        double? nullDouble = null;
        
        Console.WriteLine(
            "An integer with a null value: {0}\nA variable of type double with null value: {1}",
            nullInt,nullDouble);
        
        nullInt += 5;
        nullDouble += null;
       
        Console.WriteLine(
            "\nThe result of adding the number 5 to an integer with initial null value: {0}\nThe result of adding the null literal to a variable with initial null value: {1}\n", 
            nullInt, nullDouble);
    }
}
