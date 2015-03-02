namespace ConsoleForum.Entities.Posts
{
    using System.Text;
    using Contracts;

    public class BestAnswer : Answer
    {
        public BestAnswer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            string delimiter = new string('*', 20);
            result.AppendLine(delimiter);
            result.AppendLine(base.ToString());
            result.AppendLine(delimiter);

            return result.ToString().Trim();
        }
    }
}
