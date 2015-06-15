namespace RPG.Interfaces
{
    public interface IGameEngine
    {
        bool IsRunning { get; }

        void Run();
    }
}
