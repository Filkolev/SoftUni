namespace ConsoleForum.Entities.Posts
{
    using System.Text;
    using Contracts;

    public class Answer : Post, IAnswer
    {
        public Answer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("[ Answer ID: {0} ]", this.Id));
            result.AppendLine(base.ToString());
            result.AppendLine(string.Format("Answer Body: {0}", this.Body));
            result.AppendLine(new string('-', 20));

            return result.ToString().Trim();
        }
    }
}
