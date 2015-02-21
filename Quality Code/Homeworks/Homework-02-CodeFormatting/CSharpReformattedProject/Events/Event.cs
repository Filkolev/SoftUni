namespace Events
{
    using System;
    using System.Text;

    class Event : IComparable
    {
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int comaprisonByDate = this.date.CompareTo(other.date);
            int comparisonByTitle = this.title.CompareTo(other.title);
            int comparisonByLocation = this.location.CompareTo(other.location);

            if (comaprisonByDate == 0)
            {
                return comparisonByTitle == 0 ? comparisonByLocation : comparisonByTitle;
            }

            return comaprisonByDate;
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.title);

            if (!string.IsNullOrEmpty(this.location))
            {
                toString.Append(" | " + this.location);
            }

            return toString.ToString();
        }
    }
}