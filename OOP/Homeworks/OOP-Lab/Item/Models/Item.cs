namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    abstract class Item : IItem
    {
        private string id;
        private string title;
        private decimal price;
        private IList<string> genres;

        protected Item(string id, string title, decimal price)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
        }

        protected Item(string id, string title, decimal price, IList<string> genres)
            : this(id, title, price)
        {
            this.Genres = genres;
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("id", "ID cannot be empty.");
                }

                if (value.Length < 4)
                {
                    throw new ArgumentException("The ID must be at least 4 characters long.", "id");
                }

                this.id = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("title", "Title cannot be empty.");
                }

                this.title = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("price", "Price cannot be negative.");
                }

                this.price = value;
            }
        }

        public IList<string> Genres
        {
            get { return this.genres; }
            private set { this.genres = value ?? new List<string>(); }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(this.GetType().Name);
            result.Append(" ");
            result.AppendLine(this.Id);

            result.Append("Title: ");
            result.AppendLine(this.Title);

            result.Append("Price: ");
            result.AppendLine(string.Format("{0:f2}", this.Price));

            result.Append("Genres: ");
            result.AppendLine(string.Join(", ", this.Genres));

            return result.ToString();
        }
    }
}
