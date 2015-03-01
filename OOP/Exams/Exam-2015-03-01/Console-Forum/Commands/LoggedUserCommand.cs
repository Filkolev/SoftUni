namespace ConsoleForum.Commands
{
    using Contracts;

    /// <summary>
    /// An abstract class for all commands that require a user to be logged in the system in order to execute them.
    /// </summary>
    public abstract class LoggedUserCommand : AbstractCommand
    {
        protected LoggedUserCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }
        }
    }
}
