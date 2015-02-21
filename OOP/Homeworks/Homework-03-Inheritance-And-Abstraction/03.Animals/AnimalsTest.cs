namespace _03.Animals
{
    using System;
    using System.Linq;

    internal class AnimalsTest
    {
        private static void Main()
        {
            Animal[] animals =
            {
                new Cat("Pesho", 2, Gender.Male),
                new Dog("Sharo", 12, Gender.Male),
                new Frog("Froggy", 1, Gender.Female),
                new Kitten("Kitty", 3),
                new Tomcat("Gosho", 5),
                new Cat("Ilyo", 7, Gender.Male),
                new Frog("Hopper", 2, Gender.Female),
                new Dog("Murdzho", 17, Gender.Male),
            };

            var catsAverageAge = animals.Where(x => x is Cat).Average(x => x.Age);
            Console.WriteLine("The average age of all cats is: {0}", catsAverageAge);

            var dogsAverageAge = animals.Where(x => x is Dog).Average(x => x.Age);
            Console.WriteLine("The average age of all dogs is: {0}", dogsAverageAge);

            var frogsAverageAge = animals.Where(x => x is Frog).Average(x => x.Age);
            Console.WriteLine("The average age of all frogs is: {0}", frogsAverageAge);

            var kittensAverageAge = animals.Where(x => x is Kitten).Average(x => x.Age);
            Console.WriteLine("The average age of all kittens is: {0}", kittensAverageAge);

            var tomcatsAverageAge = animals.Where(x => x is Tomcat).Average(x => x.Age);
            Console.WriteLine("The average age of all tomcats is: {0}", tomcatsAverageAge);
        }
    }
}