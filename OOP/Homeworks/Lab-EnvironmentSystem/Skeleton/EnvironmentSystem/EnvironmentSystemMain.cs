namespace EnvironmentSystem
{
    using EnvironmentSystem.Core;

    public class EnvironmentSystemMain
    {
        static void Main()
        {
            var engine = new ExtendedEngine(new KeyboardController());
            engine.Run();
        }
    }
}
