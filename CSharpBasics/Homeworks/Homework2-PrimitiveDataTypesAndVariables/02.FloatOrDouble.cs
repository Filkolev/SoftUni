using System;

/* Which of the following values can be assigned to a variable of type float and which to a variable 
 * of type double: 34.567839023, 12.345, 8923.1234857, 3456.091? Write a program to assign the numbers 
 * in variables and print them to ensure no precision is lost. */

class FloatOrDouble
{
    static void Main()
    {
        double variable1 = 34.567839023;
        float variable2 = 12.345f;
        double variable3 = 8923.1234857;
        float variable4 = 3456.091f;
        
        
        Console.WriteLine(
            "The values of the four variables are: \n{0} \n{1} \n{2} \n{3}",
            variable1, variable2, variable3, variable4);
    }
}
