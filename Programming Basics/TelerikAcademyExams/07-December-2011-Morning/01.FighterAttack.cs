using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/21

class FighterAttack
{
    static void Main()
    {
        int targetX1 = int.Parse(Console.ReadLine());
        int targetY1 = int.Parse(Console.ReadLine());
        int targetX2 = int.Parse(Console.ReadLine());
        int targetY2 = int.Parse(Console.ReadLine());

        int fighterX = int.Parse(Console.ReadLine());
        int fighterY = int.Parse(Console.ReadLine());

        int distance = int.Parse(Console.ReadLine());
        
        int hitzoneX = fighterX + distance;
        int hitzoneY = fighterY;

        int backzoneX = hitzoneX + 1;
        int backzoneY = hitzoneY;

        int topzoneX = hitzoneX;
        int topzoneY = hitzoneY + 1;

        int bottomzoneX = hitzoneX;
        int bottomzoneY = hitzoneY - 1;

        int damage = 0;

        if (TargetHit(hitzoneX, hitzoneY, targetX1, targetX2, targetY1, targetY2))
        {
            damage += 100;
        }

        if (TargetHit(backzoneX, backzoneY, targetX1, targetX2, targetY1, targetY2))
        {
            damage += 75;
        }

        if (TargetHit(topzoneX, topzoneY, targetX1, targetX2, targetY1, targetY2))
        {
            damage += 50;
        }

        if (TargetHit(bottomzoneX, bottomzoneY, targetX1, targetX2, targetY1, targetY2))
        {
            damage += 50;
        }

        Console.WriteLine("{0}%", damage);
    }

    static bool TargetHit(int X, int Y, int targetX1, int targetX2, int targetY1, int targetY2)
    {
        int topBorder = Math.Max(targetY1, targetY2);
        int bottomBorder = Math.Min(targetY1, targetY2);
        int rightBorder = Math.Max(targetX1, targetX2);
        int leftBorder = Math.Min(targetX1, targetX2);

        bool hit = (X <= rightBorder && X >= leftBorder && Y <= topBorder && Y >= bottomBorder);
        return hit;
    }
}
