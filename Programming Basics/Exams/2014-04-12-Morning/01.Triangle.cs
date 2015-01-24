using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/53

class Triangle
{
    static void Main()
    {
        int Ax = int.Parse(Console.ReadLine());
        int Ay = int.Parse(Console.ReadLine());
        int Bx = int.Parse(Console.ReadLine());
        int By = int.Parse(Console.ReadLine());
        int Cx = int.Parse(Console.ReadLine());
        int Cy = int.Parse(Console.ReadLine());
        
        double AB = Math.Sqrt((Ax - Bx) * (Ax - Bx) + (Ay - By) * (Ay - By));
        double AC = Math.Sqrt((Ax - Cx) * (Ax - Cx) + (Ay - Cy) * (Ay - Cy));
        double BC = Math.Sqrt((Cx - Bx) * (Cx - Bx) + (Cy - By) * (Cy - By));
        
        double p = (AB + AC + BC) / 2;
        double area = Math.Sqrt(p * (p - AC) * (p - AB) * (p - BC));

        // Check if this is a triangle
        if (AB < BC + AC && AC < AB + BC && BC < AB + AC)
        {
            Console.WriteLine("Yes\n{0:F2}", area);
        }

        else
        {
            Console.WriteLine("No\n{0:F2}", AB);
        }
    }
}
