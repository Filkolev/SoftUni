using System;

// Problem can be found here: http://bgcoder.com/Contests/Practice/DownloadResource/449

class Garden
{
    static void Main()
    {
        const int totalArea = 250;

        const decimal tomatoSeedPrice = 0.5m;
        const decimal cucumberSeedPrice = 0.4m;
        const decimal potatoSeedPrice = 0.25m;
        const decimal carrotSeedPrice = 0.6m;
        const decimal cabbageSeedPrice = 0.3m;
        const decimal beansSeedPrice = 0.4m;

        int tomatoSeedsAmount = int.Parse(Console.ReadLine());
        int tomatoArea = int.Parse(Console.ReadLine());
        int cucumberoSeedsAmount = int.Parse(Console.ReadLine());
        int cucumberArea = int.Parse(Console.ReadLine());
        int potatoSeedsAmount = int.Parse(Console.ReadLine());
        int potatoArea = int.Parse(Console.ReadLine());
        int carrotSeedsAmount = int.Parse(Console.ReadLine());
        int carrotArea = int.Parse(Console.ReadLine());
        int cabbageSeedsAmount = int.Parse(Console.ReadLine());
        int cabbageArea = int.Parse(Console.ReadLine());
        int beansSeedsAmount = int.Parse(Console.ReadLine());

        decimal totalCost = 0.0m;
        totalCost += tomatoSeedPrice * tomatoSeedsAmount;
        totalCost += cucumberSeedPrice * cucumberoSeedsAmount;
        totalCost += potatoSeedPrice * potatoSeedsAmount;
        totalCost += carrotSeedPrice * carrotSeedsAmount;
        totalCost += cabbageSeedPrice * cabbageSeedsAmount;
        totalCost += beansSeedPrice * beansSeedsAmount;

        Console.WriteLine("Total costs: {0:F2}", totalCost);

        int areaUsed = tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea;

        int areaLeft = totalArea - areaUsed;

        if (areaLeft < 0)
        {
            Console.WriteLine("Insufficient area");
        }
        else if (areaLeft == 0)
        {
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Beans area: {0}", areaLeft);
        }
    }
}
