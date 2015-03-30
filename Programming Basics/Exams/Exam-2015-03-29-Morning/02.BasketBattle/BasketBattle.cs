namespace _02.BasketBattle
{
    using System;

    public class BasketBattle
    {
        public static void Main()
        {
            string startingPlayer = Console.ReadLine();

            int numberOfRounds = int.Parse(Console.ReadLine());

            int simeonPoints = 0;
            int nakovPoints = 0;

            bool isSimeonFirst = startingPlayer == "Simeon";

            for (int i = 0; i < numberOfRounds; i++)
            {
                int firstPlayerPoints = int.Parse(Console.ReadLine());
                string firstPlayerOutcome = Console.ReadLine();

                int pointsToAdd = firstPlayerOutcome == "success" ? firstPlayerPoints : 0;

                if (isSimeonFirst)
                {
                    simeonPoints += pointsToAdd;

                    if (simeonPoints == 500)
                    {
                        Console.WriteLine("Simeon");
                        Console.WriteLine(i + 1);
                        Console.WriteLine(nakovPoints);
                        return;
                    }

                    if (simeonPoints > 500)
                    {
                        simeonPoints -= pointsToAdd;
                    }
                }
                else
                {
                    nakovPoints += pointsToAdd;

                    if (nakovPoints == 500)
                    {
                        Console.WriteLine("Nakov");
                        Console.WriteLine(i + 1);
                        Console.WriteLine(simeonPoints);
                        return;
                    }

                    if (nakovPoints > 500)
                    {
                        nakovPoints -= pointsToAdd;
                    }
                }

                int secondPlayerPoints = int.Parse(Console.ReadLine());
                string secondPlayerOutcome = Console.ReadLine();

                pointsToAdd = secondPlayerOutcome == "success" ? secondPlayerPoints : 0;

                if (isSimeonFirst)
                {
                    nakovPoints += pointsToAdd;

                    if (nakovPoints == 500)
                    {
                        Console.WriteLine("Nakov");
                        Console.WriteLine(i + 1);
                        Console.WriteLine(simeonPoints);
                        return;
                    }

                    if (nakovPoints > 500)
                    {
                        nakovPoints -= pointsToAdd;
                    }
                }
                else
                {
                    simeonPoints += pointsToAdd;

                    if (simeonPoints == 500)
                    {
                        Console.WriteLine("Simeon");
                        Console.WriteLine(i + 1);
                        Console.WriteLine(nakovPoints);
                        return;
                    }

                    if (simeonPoints > 500)
                    {
                        simeonPoints -= pointsToAdd;
                    }
                }

                isSimeonFirst = !isSimeonFirst;
            }

            if (simeonPoints == nakovPoints)
            {
                Console.WriteLine("DRAW");
                Console.WriteLine(simeonPoints);
            }
            else
            {
                Console.WriteLine(simeonPoints > nakovPoints ? "Simeon" : "Nakov");

                Console.WriteLine(Math.Abs(simeonPoints - nakovPoints));
            }
        }
    }
}
