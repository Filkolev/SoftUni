namespace _03.Animals
{
    using System;

    class Kitten : Cat
    {
        public Kitten(string name, int age)
            : base(name, age, Gender.Female)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("The kitten {0} says: Meow!", this.Name);
        }
    }
}
