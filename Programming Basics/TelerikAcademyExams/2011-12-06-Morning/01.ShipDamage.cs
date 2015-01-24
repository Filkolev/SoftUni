using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/11

class ShipDamage
{
    static void Main()
    {
        int shipX1 = int.Parse(Console.ReadLine());
        int shipY1 = int.Parse(Console.ReadLine());
        int shipX2 = int.Parse(Console.ReadLine());
        int shipY2 = int.Parse(Console.ReadLine());

        int lowerBorder = Math.Min(shipY1, shipY2);
        int upperBorder = Math.Max(shipY1, shipY2);
        int rightBorder = Math.Max(shipX1, shipX2);
        int leftBorder = Math.Min(shipX1, shipX2);

        int lineOfReflection = int.Parse(Console.ReadLine());

        int totalDamage = 0;

        for (int shot = 0; shot < 3; shot++)
        {
            int projectileX = int.Parse(Console.ReadLine());
            int projectileY = int.Parse(Console.ReadLine());

            int hitPointX = projectileX;
            int hitPointY;

            int lengthOfPath = 2 * Math.Abs(projectileY - lineOfReflection);
            int position = projectileY - lineOfReflection;

            if (position < 0)
            {
                hitPointY = projectileY + lengthOfPath;
            }
            else
            {
                hitPointY = projectileY - lengthOfPath;
            }


            if (hitPointX == leftBorder && (hitPointY == upperBorder || hitPointY == lowerBorder))
            {
                totalDamage += 25;
            }
            else if (hitPointX == rightBorder && (hitPointY == upperBorder || hitPointY == lowerBorder))
            {
                 totalDamage += 25;
            }
            else if (hitPointX == leftBorder && hitPointY > lowerBorder && hitPointY < upperBorder)
            {
                totalDamage += 50;
            }
            else if (hitPointX == rightBorder && hitPointY > lowerBorder && hitPointY < upperBorder)
            {
                totalDamage += 50;
            }
            else if (hitPointY == lowerBorder && hitPointX > leftBorder && hitPointX < rightBorder)
            {
                 totalDamage += 50;
            }
            else if (hitPointY == upperBorder && hitPointX > leftBorder && hitPointX < rightBorder)
            {
                totalDamage += 50;
            }
            else if (hitPointX > leftBorder && hitPointX < rightBorder && hitPointY > lowerBorder && hitPointY < upperBorder)
            {
                totalDamage += 100;
            }
        }

        Console.WriteLine("{0}%", totalDamage);
    }
}
