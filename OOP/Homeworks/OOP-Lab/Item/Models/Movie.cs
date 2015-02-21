namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Movie : Item
    {
        private int lengthInMinutes;

        public Movie(string id, string title, decimal price, int lengthInMinutes, IList<string> genres)
            : base(id, title, price, genres)
        {
            this.LengthInMinutes = lengthInMinutes;
        }

        public Movie(string id, string title, decimal price, int lengthInMinutes, string genre)
            : this(id, title, price, lengthInMinutes, new List<string>() { genre })
        {
        }

        public int LengthInMinutes
        {
            get
            {
                return this.lengthInMinutes;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("lengthInMinutes", "The length of the movie cannot be negative.");
                }

                this.lengthInMinutes = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.Append("Length: ");
            result.AppendLine(this.LengthInMinutes.ToString());

            return result.ToString();
        }
    }
}
