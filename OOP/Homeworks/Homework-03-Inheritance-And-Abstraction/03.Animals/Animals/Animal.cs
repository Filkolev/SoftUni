namespace _03.Animals
{
    using System;
    using Contracts;

    abstract class Animal : ISound
    {
        private string name;
        private int age;

        protected Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "Name cannot be empty.");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("age", "Age cannot be negative.");
                }

                this.age = value;
            }
        }

        public Gender Gender { get; set; }

        public abstract void ProduceSound();
    }
}
