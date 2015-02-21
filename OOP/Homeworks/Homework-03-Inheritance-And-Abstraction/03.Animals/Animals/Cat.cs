namespace _03.Animals
{
    using System;

    class Cat : Animal
    {
        public Cat(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("The cat {0} says: Meow!", this.Name);
        }
    }
}
