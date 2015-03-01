namespace ConsoleForum.Commands
{
    using Contracts;
    using Entities.Posts;

    public class PostAnswerCommand : LoggedUserCommand
    {
        public PostAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            base.Execute();

            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            string body = this.Data[1];

            var answer = new Answer(this.Forum.Answers.Count + 1, body, this.Forum.CurrentUser);

            this.Forum.Answers.Add(answer);
            this.Forum.CurrentQuestion.Answers.Add(answer);

            this.Forum.Output.AppendLine(
                string.Format(Messages.PostAnswerSuccess, answer.Id));
        }
    }
}
