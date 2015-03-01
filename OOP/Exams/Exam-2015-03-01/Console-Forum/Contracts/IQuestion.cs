namespace ConsoleForum.Contracts
{
    using System.Collections.Generic;

    public interface IQuestion : IPost
    {
        string Title { get; set; }

        IList<IAnswer> Answers { get; }
    }
}
