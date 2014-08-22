using System;

/* The gravitational field of the Moon is approximately 17% of that on the Earth. 
 Write a program that calculates the weight of a man on the moon by a given weight on the Earth. */

class GravitationOnTheMoon
{
    static void Main()
    {
        Console.Write("Please enter the weight on Earth: ");
        double weight = double.Parse(Console.ReadLine());
        double weightOnMoon = 0.17 * weight;
        Console.WriteLine("\nThe weight on the Moon will be approximately {0}.\n", weightOnMoon);
    }
}
