namespace ConsoleForum.Commands
{
    using System.Linq;
    using Contracts;
    using Entities.Users;
    using Utility;

    public class RegisterCommand : AbstractCommand
    {
        public RegisterCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);
            string email = this.Data[3];

            if (users.Any(u => u.Username == username || u.Email == email))
            {
                throw new CommandException(Messages.UserAlreadyRegistered);
            }
           
            User user;

            if (this.Data.Count > 4)
            {
                var role = this.Data[4];

                switch (role.ToLower())
                {
                    case "administrator":
                        if (users.Any())
                        {
                            throw new CommandException(Messages.RegAdminNotAllowed);
                        }

                        user = new Administrator(1, username, password, email);
                        break;
                    default:
                        user = new User(users.Count + 1, username, password, email);
                        break;
                }
            }
            else
            {
                user = new User(users.Count + 1, username, password, email);
            }

            users.Add(user);

            this.Forum.Output.AppendLine(
                string.Format(Messages.RegisterSuccess, username, users.Last().Id));
        }
    }
}
