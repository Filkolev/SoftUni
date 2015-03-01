namespace ConsoleForum.Commands
{
    using System.Linq;
    using Contracts;
    using Entities.Posts;

    public class MakeBestAnswerCommand : LoggedUserCommand
    {
        public MakeBestAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            base.Execute();

            var question = this.Forum.CurrentQuestion;

            if (question == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            int answerId = int.Parse(this.Data[1]);

            var answer = question.Answers
                .FirstOrDefault(a => a.Id == answerId);

            if (answer == null)
            {
                throw new CommandException(Messages.NoAnswer);
            }

            var user = this.Forum.CurrentUser;

            var hasUserPermissionToExecuteCommand = HasUserPermissionToExecuteCommand(user, question);

            if (!hasUserPermissionToExecuteCommand)
            {
                throw new CommandException(Messages.NoPermission);
            }
            
            this.MakeAnswerBestAnswer(question, answer);

            this.Forum.Output.AppendLine(
               string.Format(Messages.BestAnswerSuccess, answer.Id));
        }

        /// <summary>
        /// Checks whether the user has sufficient privileges to choose a best answer for the given question.
        /// </summary>
        /// <param name="user">The user attempting to execute the command.</param>
        /// <param name="question">The question for which a best answer is being chosen.</param>
        /// <returns>Returns True if the user has sufficient privileges to execute the command or False otherwise. </returns>
        private static bool HasUserPermissionToExecuteCommand(IUser user, IQuestion question)
        {
            bool hasUserPermissionToExecuteCommand = user is IAdministrator || user.Username == question.Author.Username;

            return hasUserPermissionToExecuteCommand;
        }

        private void MakeAnswerBestAnswer(IQuestion question, IAnswer answer)
        {
            this.RemoveCurrentAnswerFromDatabase(question, answer);

            var bestAnswer = new BestAnswer(answer.Id, answer.Body, answer.Author);

            this.AddBestAnswerToDatabase(question, bestAnswer);
        }

        private void RemoveCurrentAnswerFromDatabase(IQuestion question, IAnswer answer)
        {
            question.Answers.Remove(answer);
            this.Forum.Answers.Remove(answer);
        }

        private void AddBestAnswerToDatabase(IQuestion question, IAnswer answer)
        {
            question.Answers.Add(answer);
            this.Forum.Answers.Add(answer);
        }
    }
}
