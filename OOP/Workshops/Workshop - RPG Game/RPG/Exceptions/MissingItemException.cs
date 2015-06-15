namespace RPG.Exceptions
{
    using System;

    public class MissingItemException : Exception
    {
        public MissingItemException(string msg)
            : base(msg)
        {
        }
    }
}
