namespace ConsoleForum.Contracts
{
    public interface ICommand : IExecutable
    {
        IForum Forum { get; }
    }
}
