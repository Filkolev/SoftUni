namespace Item.Core
{
    using System;

    class InsufficientSuppliesException : ApplicationException
    {
        public InsufficientSuppliesException()
        {
        }

        public InsufficientSuppliesException(string message)
            : base(message)
        {
        }

        public InsufficientSuppliesException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
