namespace Interfaces
{
    using System;

    interface ISale
    {
        IItem ItemSold { get; }

        DateTime DateOfPurchase { get; }
    }
}
