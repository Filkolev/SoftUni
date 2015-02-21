namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Book : Item
    {
        private string author;

        public Book(string id, string title, decimal price, string author, IList<string> genres)
            : base(id, title, price, genres)
        {
            this.Author = author;
        }

        public Book(string id, string title, decimal price, string author, string genre)
            : this(id, title, price, author, new List<string>() { genre })
        {
        }

        public string Author
        {
            get
            {
                return this.author;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("author", "Author cannot be empty.");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Author should contain at least 3 symbols.", "author");
                }

                this.author = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.Append("Author: ");
            result.AppendLine(this.Author);

            return result.ToString();
        }
    }
}
