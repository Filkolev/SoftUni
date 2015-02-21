namespace _03.StudentClass
{
    using System;

    class Student
    {
        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
                    throw new ArgumentNullException("name", "Name cannot be empty");
                }

                if (value.Length < 2)
                {
                    throw new ArgumentException("The student's name should be at least two characters long.", "name");
                }

                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Name", this.Name, value);
                this.OnPropertyChanged(this, args);

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
                if (value < 0 || 150 < value)
                {
                    throw new ArgumentOutOfRangeException("age", "Age should be in the range [0 ... 150].");
                }

                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Age", this.Age, value);
                this.OnPropertyChanged(this, args);

                this.age = value;
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(sender, args);
            }
        }
    }
}
