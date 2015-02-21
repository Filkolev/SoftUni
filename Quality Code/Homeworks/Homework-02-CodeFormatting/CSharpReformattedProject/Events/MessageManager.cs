namespace Events
{
    internal static class MessageManager
    {
        public static void PrintEventAdded()
        {
            CommandManager.Output.Append("Event added\n");
        }

        public static void PrintEventDeleted(int x)
        {
            if (x == 0)
            {
                PrintNoEventsFound();
            }
            else
            {
                CommandManager.Output.AppendFormat("{0} events deleted\n", x);
            }
        }

        public static void PrintNoEventsFound()
        {
            CommandManager.Output.Append("No events found\n");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                CommandManager.Output.Append(eventToPrint + "\n");
            }
        }
    }
}