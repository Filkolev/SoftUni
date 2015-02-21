namespace Models
{
    using System.Collections.Generic;
    using System.Text;

    class Game : Item
    {
        public Game(string id, string title, decimal price, IList<string> genres, AgeRestriction ageRestriction = AgeRestriction.Minor)
            : base(id, title, price, genres)
        {
            this.AgeRestriction = ageRestriction;
        }

        public Game(string id, string title, decimal price, string genre, AgeRestriction ageRestriction = AgeRestriction.Minor)
            : this(id, title, price, new List<string>() { genre }, ageRestriction)
        {
        }

        public AgeRestriction AgeRestriction { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.Append("Age Restriction: ");
            result.AppendLine(this.AgeRestriction.ToString());

            return result.ToString();
        }
    }
}
