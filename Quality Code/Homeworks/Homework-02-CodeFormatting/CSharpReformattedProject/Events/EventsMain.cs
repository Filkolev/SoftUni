namespace Events
{
    using System;

    class EventsMain
    {
        static void Main()
        {
            while (CommandManager.ExecuteNextCommand())
            {
            }

            Console.WriteLine(CommandManager.Output);
        }
    }
}
