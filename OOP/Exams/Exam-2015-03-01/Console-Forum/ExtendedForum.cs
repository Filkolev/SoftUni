namespace ConsoleForum
{
    using System;
    using System.Linq;
    using System.Text;
    using Entities.Posts;

    public class ExtendedForum : Forum
    {
        protected override void ExecuteCommandLoop()
        {
            string welcomeMessage = this.GetWelcomeMessage();

            this.Output.Clear();
            this.Output.AppendLine(welcomeMessage);
            Console.Write(this.Output);

            base.ExecuteCommandLoop();
        }

        private string GetWelcomeMessage()
        {
            StringBuilder welcomeMessage = new StringBuilder();

            string delimiter = new string('~', 20);
            welcomeMessage.AppendLine(delimiter);

            if (!this.IsLogged)
            {
                welcomeMessage.AppendLine(Messages.GuestWelcomeMessage);
            }
            else
            {
                welcomeMessage.AppendLine(string.Format(
                    Messages.UserWelcomeMessage,
                    this.CurrentUser.Username));
            }

            int countOfHotQuestions = this.GetNumberOfHotQuestions();
            int countOfActiveUsers = this.GetNumberOfActiveUsers();

            welcomeMessage.AppendLine(string.Format(
                Messages.GeneralHeaderMessage, 
                countOfHotQuestions, 
                countOfActiveUsers));

            welcomeMessage.AppendLine(delimiter);

            return welcomeMessage.ToString().Trim();
        }

        private int GetNumberOfHotQuestions()
        {
            int countOfHotQuestons = this.Questions
                .Count(question => question.Answers
                    .Any(answer => answer is BestAnswer));

            return countOfHotQuestons;
        }

        private int GetNumberOfActiveUsers()
        {
            const int MinNumberOfPostsForActiveUser = 3;

            var countOfActiveUsers = this.Users
                .Select(user => this.Answers
                    .Count(answer => answer.Author == user))
                .Count(countOfAnswersForCurrentUser => countOfAnswersForCurrentUser >= MinNumberOfPostsForActiveUser);

            return countOfActiveUsers;
        }
    }
}
