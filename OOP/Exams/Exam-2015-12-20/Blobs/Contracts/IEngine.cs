namespace Blobs.Contracts
{
    public interface IEngine : IRunnable, IUpdateable
    {
        void ProcessCommand(string[] commandArgs);
    }
}
