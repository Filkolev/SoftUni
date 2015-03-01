namespace ConsoleForum.Commands
{
    using System.Collections.Generic;

    using Contracts;

    public abstract class AbstractCommand : ICommand
    {
        public readonly List<string> Data = new List<string>();

        protected AbstractCommand(IForum forum)
        {
            this.Forum = forum;
        }

        public IForum Forum { get; private set; }

        public abstract void Execute();
    }
}
