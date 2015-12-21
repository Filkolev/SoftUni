namespace Blobs.UI
{
    using System;

    using Contracts;

    public class ConsoleWriter : IOutputWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
