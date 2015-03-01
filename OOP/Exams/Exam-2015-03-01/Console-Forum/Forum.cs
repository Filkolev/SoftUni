namespace ConsoleForum
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Commands;
    using Contracts;

    public class Forum : IForum
    {
        private const string DefaultAdminUser = "admin";
        private const string DefaultAdminPassword = "admin";
        private const string DefaultAdminEmail = "admin@example.com";

        public Forum()
        {
            this.Users = new List<IUser>();
            this.Questions = new List<IQuestion>();
            this.Answers = new List<IAnswer>();
            this.HasStarted = true;
            this.Output = new StringBuilder();
        }

        public bool HasStarted { get; set; }

        public IList<IUser> Users { get; private set; }

        public IList<IQuestion> Questions { get; private set; }

        public IList<IAnswer> Answers { get; private set; }

        public IQuestion CurrentQuestion { get; set; }

        public bool IsLogged
        {
            get
            {
                return this.CurrentUser != null;
            }
        }

        public IUser CurrentUser { get; set; }

        public StringBuilder Output { get; private set; }

        public virtual void Run()
        {
            this.Setup();

            while (this.HasStarted)
            {
                this.ExecuteCommandLoop();
            }
        }

        protected virtual void ExecuteCommandLoop()
        {
            this.Output.Clear();
            var inputCommand = Console.ReadLine();

            try
            {
                IExecutable command = CommandFactory.Create(inputCommand, this);
                command.Execute();
            }
            catch (CommandException ex)
            {
                this.Output.AppendLine(ex.Message);
            }
            catch (InvalidOperationException)
            {
                this.Output.AppendLine(Messages.InvalidCommand);
            }

            Console.Write(this.Output);
        }

        protected virtual void Setup()
        {
            string registerAdminCommand = string.Format(
                "register {0} {1} {2} ADMINISTRATOR",
                DefaultAdminUser,
                DefaultAdminPassword,
                DefaultAdminEmail);

            IExecutable command = CommandFactory.Create(registerAdminCommand, this);
            command.Execute();
        }
    }
}
