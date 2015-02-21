namespace EnvironmentSystem.Interfaces
{
    using System;

    public interface IController
    {
        event EventHandler Pause;

        void ProcessInput();
    }
}
