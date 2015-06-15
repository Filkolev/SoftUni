namespace RPG.Exceptions
{
    using System;

    public class LocationOutOfRangeException : Exception
    {
        public LocationOutOfRangeException()
            : base("Specified location is outside map boundaries.")
        {
        }
    }
}
