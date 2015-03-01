namespace ConsoleForum.Entities.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;

    public class Question : Post, IQuestion
    {
        private string title;

        public Question(int id, string body, IUser author, string title)
            : base(id, body, author)
        {
            this.Title = title;
            this.Answers = new List<IAnswer>();
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("title", "The title of a question cannot be empty.");
                }

                this.title = value;
            }
        }

        public IList<IAnswer> Answers { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("[ Question ID: {0} ]", this.Id));
            result.AppendLine(base.ToString());
            result.AppendLine(string.Format("Question Title: {0}", this.Title));
            result.AppendLine(string.Format("Question Body: {0}", this.Body));
            result.AppendLine(new string('=', 20));

            if (this.Answers.Any())
            {
                result.AppendLine("Answers:");

                var bestAnswer = this.GetBestAnswer();

                if (bestAnswer != null)
                {
                    result.AppendLine(bestAnswer.ToString());
                }

                var regularAnswers = this.GetRegularAnswersSortedById();

                foreach (var answer in regularAnswers)
                {
                    result.AppendLine(answer.ToString());
                }
            }
            else
            {
                result.Append("No answers");
            }

            return result.ToString().Trim();
        }

        private IAnswer GetBestAnswer()
        {
            var bestAnswer = this.Answers.FirstOrDefault(answer => answer is BestAnswer);

            return bestAnswer;
        }

        private List<IAnswer> GetRegularAnswersSortedById()
        {
            var sortedRegularAsnwers = this.Answers
                .Where(answer => !(answer is BestAnswer))
                .OrderBy(answer => answer.Id)
                .ToList();

            return sortedRegularAsnwers;
        }
    }
}
