namespace Interfaces
{
    using System.Collections.Generic;

    interface IItem
    {
        string Id { get; }

        string Title { get; }

        decimal Price { get; }

        IList<string> Genres { get; }
    }
}
