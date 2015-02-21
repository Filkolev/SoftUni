namespace Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;

    static class RentManager
    {
        static readonly HashSet<IRent> Rents = new HashSet<IRent>();

        public static void AddRent(IItem itemRented, DateTime rentDate, DateTime returnDeadline)
        {
            IRent rent = new Rent(itemRented, rentDate, returnDeadline);
            Rents.Add(rent);
        }

        public static List<IRent> GetOverdueRents()
        {
            var overdueRents =
                Rents.Where(rent => rent.RentStatus == RentStatus.Overdue)
                    .OrderBy(rent => rent.CalculateRentFine())
                    .ThenBy(rent => rent.ItemRented.Title);

            return overdueRents.ToList();
        }
    }
}
