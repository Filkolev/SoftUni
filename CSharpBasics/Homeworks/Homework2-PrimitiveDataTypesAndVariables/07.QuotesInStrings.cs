using System;

/* Declare two string variables and assign them with following value:
'The "use" of quotations causes difficulties.'
 
Do the above in two different ways: with and without using quoted strings. Print the 
variables to ensure that their value was correctly defined.*/

class QuotesInStrings
{
    static void Main()
    {
        string methodOne = "The \"use\" of quotations causes difficulties.";
        
        Console.WriteLine(
            new string('-',52) + "\nMethod 1: using normal quotation and escaping with \\\n" + new string('-', 52)+"\n\n{0}",
            methodOne);

        string methodTwo = @"The ""use"" of quotations causes difficulties.";
       
        Console.WriteLine(
            "\n\n\n"+new string('-', 54) + "\nMethod 2: using verbatim quotation and escaping with \"\n" + new string('-', 54) + "\n\n{0}",
            methodTwo);
    }
}
