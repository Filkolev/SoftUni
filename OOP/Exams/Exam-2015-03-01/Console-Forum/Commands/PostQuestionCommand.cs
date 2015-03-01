namespace ConsoleForum.Commands
{
    using Contracts;
    using Entities.Posts;

    public class PostQuestionCommand : LoggedUserCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            base.Execute();

            string title = this.Data[1];
            string body = this.Data[2];

            var newQuestion = new Question(this.Forum.Questions.Count + 1, body, this.Forum.CurrentUser, title);

            this.Forum.Questions.Add(newQuestion);

            this.Forum.Output.AppendLine(
                string.Format(Messages.PostQuestionSuccess, newQuestion.Id));
        }
    }
}
