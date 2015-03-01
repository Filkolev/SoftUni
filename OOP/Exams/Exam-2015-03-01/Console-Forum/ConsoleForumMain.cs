namespace ConsoleForum
{
    using Contracts;

    public class ConsoleForumMain
    {
        public static void Main()
        {
            IForum forum = new ExtendedForum();
            forum.Run();
        }
    }
}
