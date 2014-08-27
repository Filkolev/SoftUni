using System;

class Tables
{
    static void Main()
    {
        long legs = 0;

        for (int i = 0; i < 4; i++)
        {            
            legs += (i + 1) * long.Parse(Console.ReadLine());
        }

        long tops = long.Parse(Console.ReadLine());

        long tablesNeeded = long.Parse(Console.ReadLine());

        long usefulLegs = legs / 4;

        long tablesMade = Math.Min(tops, usefulLegs);

        long legsNeeded = tablesNeeded * 4;
        long legsDeficit = Math.Max(0, legsNeeded - legs);
        long topsDeficit = Math.Max(0, tablesNeeded - tops);

        long legsExtra = Math.Max(0, legs - legsNeeded);
        long topsExtra = Math.Max(0, tops - tablesNeeded);

        long margin = tablesMade - tablesNeeded;

        if (margin > 0)
        {
            Console.WriteLine("more: {0}", margin);
            Console.WriteLine("tops left: {0}, legs left: {1}", topsExtra, legsExtra);
        }
        else if (margin < 0)
        {
            Console.WriteLine("less: {0}", margin);
            Console.WriteLine("tops needed: {0}, legs needed: {1}", topsDeficit, legsDeficit);
        }
        else
        {
            Console.WriteLine("Just enough tables made: {0}", tablesNeeded);
        }        
    }
}
