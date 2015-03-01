namespace ConsoleForum.Contracts
{
    using System.Collections.Generic;
    using System.Text;

    public interface IForum
    {
        bool HasStarted { get; set; }

        IList<IUser> Users { get; }

        IList<IQuestion> Questions { get; }

        IList<IAnswer> Answers { get; }

        IQuestion CurrentQuestion { get; set; }

        bool IsLogged { get; }

        IUser CurrentUser { get; set; }

        StringBuilder Output { get; }

        void Run();
    }
}
