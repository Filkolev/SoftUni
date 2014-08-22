using System;

/* Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001. 
 Note that we cannot directly compare two floating-point numbers a and b by a==b because of the nature 
 of the floating-point arithmetic. Therefore, we assume two numbers are equal if they are more closely 
 to each other than a fixed constant eps. */

class ComparingFloats
{
    static void Main()
    {
        Console.WriteLine("Please enter two floating-point numbers to compare (make sure to use the correct decimal symbol based on your system's settings)");    

        double Float1 = double.Parse(Console.ReadLine()); 
        double Float2 = double.Parse(Console.ReadLine());

        /* Checks whether the difference in absolute value between the two numbers 
        is smaller than the specified epsilon */

        if (Math.Abs(Float1 - Float2) < 0.000001) 
        {
            // If the difference is small enough we consider the two numbers equal
            Console.WriteLine("The two numbers are equal with precision 0.000001"); 
        }
        else
        {            
            Console.WriteLine("The two numbers are NOT equal with precision 0.000001"); 
        }
    }
}
