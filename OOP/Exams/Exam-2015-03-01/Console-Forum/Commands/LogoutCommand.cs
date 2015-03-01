namespace ConsoleForum.Commands
{
    using Contracts;

    public class LogoutCommand : LoggedUserCommand
    {
        public LogoutCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            base.Execute();

            this.Forum.CurrentUser = null;
            this.Forum.CurrentQuestion = null;

            this.Forum.Output.AppendLine(
                string.Format(Messages.LogoutSuccess));
        }
    }
}
