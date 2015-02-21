namespace EnvironmentSystem.Core
{
    using Interfaces;
    using Models;

    class ExtendedEngine : Engine
    {
        private IController controller;
        public static bool isPaused = false;

        public ExtendedEngine(IController controller)
        {
            this.controller = controller;
            this.controller.Pause += (obj, args) =>
            {
                isPaused = !isPaused;
            };
        }

        protected override void ExecuteEnvironmentLoop()
        {
            this.controller.ProcessInput();

            if (!isPaused)
            {
                base.ExecuteEnvironmentLoop();
            }
        }

        protected override void Insert(EnvironmentObject obj)
        {
            if (obj != null)
            {
                base.Insert(obj);
            }
        }
    }
}
