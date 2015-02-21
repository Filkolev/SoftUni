namespace Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;

    static class SaleManager
    {
        private static readonly HashSet<ISale> Sales = new HashSet<ISale>();

        public static void AddSale(IItem itemSold, DateTime dateOfSale)
        {
            ISale sale = new Sale(itemSold, dateOfSale);
            Sales.Add(sale);
        }

        public static decimal GetSaleAmountToDate(DateTime startDate)
        {
            var salesToDate = Sales.Where(sale => sale.DateOfPurchase >= startDate);
            decimal purchaseAmountToDate = salesToDate.Sum(sale => sale.ItemSold.Price);

            return purchaseAmountToDate;
        }
    }
}
