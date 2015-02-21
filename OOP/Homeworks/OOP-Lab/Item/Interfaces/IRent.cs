namespace Interfaces
{
    using System;
    using Models;

    interface IRent
    {
        IItem ItemRented { get; }

        RentStatus RentStatus { get; }

        DateTime DateOfRent { get; }

        DateTime ReturnDeadline { get; }

        DateTime ReturnDate { get; }

        decimal CalculateRentFine();
    }
}
