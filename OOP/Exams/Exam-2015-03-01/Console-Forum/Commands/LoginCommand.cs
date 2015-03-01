namespace ConsoleForum.Commands
{
    using System.Linq;
    using Contracts;
    using Utility;

    public class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.IsLogged)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);

            IUser user = this.Forum.Users
                .FirstOrDefault(u => u.Username == username);

            if (user == null || user.Password != password)
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }

            this.Forum.CurrentUser = user;

            this.Forum.Output.AppendLine(
                string.Format(Messages.LoginSuccess, username));
        }
    }
}
