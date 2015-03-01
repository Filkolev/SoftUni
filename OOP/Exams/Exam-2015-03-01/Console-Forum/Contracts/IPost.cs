namespace ConsoleForum.Contracts
{
    public interface IPost
    {
        int Id { get; set; }

        string Body { get; set; }

        IUser Author { get; set; }
    }
}
