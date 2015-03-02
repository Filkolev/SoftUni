namespace ConsoleForum
{
    using Contracts;

    public class ConsoleForumMain
    {
        public static void Main()
        {
            IForum forum = new Forum();
            forum.Run();
        }
    }
}
