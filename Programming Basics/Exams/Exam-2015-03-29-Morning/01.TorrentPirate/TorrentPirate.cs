namespace _01.TorrentPirate
{
    using System;

    public class TorrentPirate
    {
        public static void Main()
        {
            const int MovieSize = 1500;
            const int DownloadSpeed = 2;
            const int SecondsPerHour = 60 * 60;

            double downloadData = int.Parse(Console.ReadLine());
            int cinemaPrice = int.Parse(Console.ReadLine());
            int wifeSpendingPerHour = int.Parse(Console.ReadLine());

            double downloadTimeInSeconds = downloadData / DownloadSpeed;
            double downloadTimeInHours = downloadTimeInSeconds / SecondsPerHour;
            double costAtMall = downloadTimeInHours * wifeSpendingPerHour;

            double moviesToDownload = downloadData / MovieSize;

            double costAtCinema = moviesToDownload * cinemaPrice;

            if (costAtMall <= costAtCinema)
            {
                Console.WriteLine("{0} -> {1:f2}lv", "mall", costAtMall);
            }
            else
            {
                Console.WriteLine("{0} -> {1:f2}lv", "cinema", costAtCinema);
            }
        }
    }
}
