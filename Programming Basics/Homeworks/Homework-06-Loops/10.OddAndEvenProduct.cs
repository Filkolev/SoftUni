using System;
using System.Numerics;

/* You are given n integers (given in a single line, separated by a space). 
 Write a program that checks whether the product of the odd elements is equal 
 to the product of the even elements. Elements are counted from 1 to n, so the 
 first element is odd, the second is even, etc. */

class OddAndEvenProduct
{
    static void Main()
    {        
        Console.WriteLine("Enter the input line:");
        string[] nums = Console.ReadLine().Split();   
     
        BigInteger oddProduct = 1;
        BigInteger evenProduct = 1;

        for (int i = 1; i <= nums.Length; i++)
        {            
            
            int currentNumber = Convert.ToInt32(nums[i - 1]);

            if (i % 2 == 0)
            {
                evenProduct *= currentNumber;
            }
            else
            {
                oddProduct *= currentNumber;
            }
        }

        Console.WriteLine();

        if (oddProduct == evenProduct)
        {
            Console.WriteLine("yes\nproduct = {0}", oddProduct);
        }

        else
        {
            Console.WriteLine("no\nodd_product = {0}\neven_product = {1}",
                oddProduct, evenProduct);
        }
    }
}
