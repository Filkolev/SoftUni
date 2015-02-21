namespace EnvironmentSystem.Interfaces
{
    using EnvironmentSystem.Models.Data.Structures;

    public interface IRenderable
    {
        Rectangle Bounds { get; }

        char[,] ImageProfile { get; }
    }
}
