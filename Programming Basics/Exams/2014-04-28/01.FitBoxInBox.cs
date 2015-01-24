using System;

// Problem can be found here: http://judge.softuni.bg/Contests/Practice/DownloadResource/100

class FitBoxInBox
{
    static void Main()
    {
        int width1 = int.Parse(Console.ReadLine());
        int height1 = int.Parse(Console.ReadLine());
        int depth1 = int.Parse(Console.ReadLine());

        int width2 = int.Parse(Console.ReadLine());
        int height2 = int.Parse(Console.ReadLine());
        int depth2 = int.Parse(Console.ReadLine());

        // If the second box is smaller, switch the boxes
        if (width1 + height1 + depth1 > width2 + height2 + depth2) 
        {
            int tempWidth = width1;
            int tempHeight = height1;
            int tempDepth = depth1;

            width1 = width2;
            width2 = tempWidth;

            height1 = height2;
            height2 = tempHeight;

            depth1 = depth2;
            depth2 = tempDepth;
        }


        if (width1 < width2 
            && height1 < height2 
            && depth1 < depth2)
        {
            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", 
                width1, height1, depth1, width2, height2, depth2);
        }

        if (width1 < width2 
            && height1 < depth2 
            && depth1 < height2)
        {
            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", 
                width1, height1, depth1, width2, depth2, height2);
        }

        if (width1 < height2 
            && height1 < width2 
            && depth1 < depth2)
        {
            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", 
                width1, height1, depth1, height2, width2, depth2);
        }

        if (width1 < height2 
            && height1 < depth2 
            && depth1 < width2)
        {
            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", 
                width1, height1, depth1, height2, depth2, width2);
        }

        if (width1 < depth2 
            && height1 < height2 
            && depth1 < width2)
        {
            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", 
                width1, height1, depth1, depth2, height2, width2);
        }

        if (width1 < depth2 
            && height1 < width2 
            && depth1 < height2)
        {
            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", 
                width1, height1, depth1, depth2, width2, height2);
        }
    }
}
