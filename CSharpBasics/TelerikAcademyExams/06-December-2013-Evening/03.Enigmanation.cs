using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/515

class Enigmanation
{
    static void Main()
    {
        double result = 0.0;
        double innerResult = 0.0;
        char currentOperation = '0';

        while (currentOperation != '=')
        {
            char currentSymbol = (char)Console.Read();

            if (currentSymbol == '(')
            {
                innerResult = CalculateInnerExpression();

                if (currentOperation != '0')
                {
                    result = PerformOperation(result, currentOperation, innerResult);
                }
                else
                {
                    result = innerResult;
                }
            }

            else
            {
                if (currentOperation != '0')
                {
                    result = PerformOperation(result, currentOperation, currentSymbol - '0');
                }
                else
                {
                    result += currentSymbol - '0';
                }
            }

            currentOperation = (char)Console.Read();
        }

        Console.WriteLine("{0:F3}", result);        
    }

    static double CalculateInnerExpression()
    {
        double result = 0.0;

        int firstDigit = Console.Read() - '0';
        result += firstDigit;

        while (true)
        {
            char currentOperation = (char)Console.Read();
            if (currentOperation == ')')
            {
                break;
            }

            int nextDigit = Console.Read() - '0';

            result = PerformOperation(result, currentOperation, nextDigit);
        }

        return result;
    }

    private static double PerformOperation(double result, char currentOperation, double nextDigit)
    {
        switch (currentOperation)
        {
            case '+': result += nextDigit; break;
            case '-': result -= nextDigit; break;
            case '*': result *= nextDigit; break;
            case '%': result %= nextDigit; break;
        }
        return result;
    }
}
