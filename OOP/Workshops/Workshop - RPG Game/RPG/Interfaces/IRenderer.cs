namespace RPG.Interfaces
{
    public interface IRenderer
    {
        void WriteLine(string message, params object[] parameters);

        void Clear();
    }
}
