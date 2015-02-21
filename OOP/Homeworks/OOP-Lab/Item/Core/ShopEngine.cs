namespace Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Interfaces;
    using Item.Core;
    using Models;

    static class ShopEngine
    {
        private const string DateFormat = "dd-MM-yyyy";
        private static readonly Dictionary<IItem, int> StoreSupplies = new Dictionary<IItem, int>();

        public static void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();
                string[] commandData = command.Split();

                switch (commandData[0])
                {
                    case "supply":
                        ExecuteSupplyCommand(commandData);
                        break;
                    case "sell":
                        ExecuteSellCommand(commandData);
                        break;
                    case "rent":
                        ExecuteRentCommand(commandData);
                        break;
                    case "report":
                        ExecuteReportCommand(commandData);
                        break;
                    case "return":
                        throw new NotImplementedException("Command has not been implemented yet.");
                    default:
                        throw new ArgumentException("Input was not recognized as valid command.", "command");
                }
            }
        }

        private static void ExecuteSupplyCommand(string[] commandData)
        {
            IItem itemToSupply = ParseItem(commandData);
            int quantity = int.Parse(commandData[2]);

            SupplyItem(itemToSupply, quantity);
        }

        private static void ExecuteSellCommand(string[] commandData)
        {
            IItem itemToSell = GetItemById(commandData[1]);
            DateTime dateOfSale = DateTime.ParseExact(
                commandData[2],
                DateFormat,
                CultureInfo.InvariantCulture);

            UpdateSupplies(itemToSell);
            SaleManager.AddSale(itemToSell, dateOfSale);
        }

        private static void ExecuteRentCommand(string[] commandData)
        {
            IItem itemToRent = GetItemById(commandData[1]);
            DateTime dateOfRent = DateTime.ParseExact(
                commandData[2],
                DateFormat,
                CultureInfo.InvariantCulture);
            DateTime returnDeadline = DateTime.ParseExact(
                commandData[3],
                DateFormat,
                CultureInfo.InvariantCulture);

            UpdateSupplies(itemToRent);
            RentManager.AddRent(itemToRent, dateOfRent, returnDeadline);
        }

        private static void ExecuteReportCommand(string[] commandData)
        {
            switch (commandData[1])
            {
                case "rents":
                    var rentsToReport = RentManager.GetOverdueRents();
                    foreach (var rent in rentsToReport)
                    {
                        Console.WriteLine(rent);
                    }

                    break;
                case "sales":
                    DateTime startDate = DateTime.ParseExact(
                        commandData[2],
                        DateFormat,
                        CultureInfo.InvariantCulture);
                    decimal purchaseAmount = SaleManager.GetSaleAmountToDate(startDate);
                    Console.WriteLine(purchaseAmount);
                    break;
                default:
                    throw new ArgumentException("Input was not recognized as valid command.", "command");
            }
        }

        private static void SupplyItem(IItem item, int quantity)
        {
            var currentObjectInSupply =
                StoreSupplies.Keys.FirstOrDefault(
                    existingItem =>
                        existingItem.Id == item.Id &&
                        existingItem.Title == item.Title &&
                        existingItem.Price == item.Price);

            if (currentObjectInSupply == null)
            {
                StoreSupplies.Add(item, quantity);
            }
            else
            {
                StoreSupplies[currentObjectInSupply] += quantity;
            }
        }

        private static IItem ParseItem(string[] data)
        {
            string itemType = data[1];
            string paramsString = data[3];
            Dictionary<string, string> itemAttributesAndValues = ParseParams(paramsString);

            IItem item = CreateItemFromData(itemAttributesAndValues, itemType);

            return item;
        }

        private static Dictionary<string, string> ParseParams(string paramsString)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            string[] pairs = paramsString.Split('&');

            foreach (var pair in pairs)
            {
                string[] keyValuePair = pair.Split('=');
                keyValuePairs[keyValuePair[0]] = keyValuePair[1];
            }

            return keyValuePairs;
        }

        private static IItem CreateItemFromData(Dictionary<string, string> attributesAndValuePairs, string type)
        {
            string id = attributesAndValuePairs["id"];
            string title = attributesAndValuePairs["title"];
            string priceAsSting = attributesAndValuePairs["price"];
            decimal price = decimal.Parse(priceAsSting);
            string genre = attributesAndValuePairs["genre"];

            IItem item;
            switch (type)
            {
                case "book":
                    string author = attributesAndValuePairs["author"];
                    item = new Book(id, title, price, author, genre);
                    break;
                case "movie":
                case "video":
                    string lengthAsString = attributesAndValuePairs["length"];
                    int lengthInMinutes = int.Parse(lengthAsString);
                    item = new Movie(id, title, price, lengthInMinutes, genre);
                    break;
                case "game":
                    string ageRestrictionAsString = attributesAndValuePairs["ageRestriction"];
                    AgeRestriction ageRestriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), ageRestrictionAsString);
                    item = new Game(id, title, price, genre, ageRestriction);
                    break;
                default:
                    throw new ArgumentException("Item type was not recognized.", "type");
            }

            return item;
        }

        private static IItem GetItemById(string id)
        {
            var itemEntry = StoreSupplies.FirstOrDefault(itemInStore => itemInStore.Key.Id == id);

            return itemEntry.Key;
        }

        private static void UpdateSupplies(IItem item)
        {
            if (item == null || StoreSupplies[item] == 0)
            {
                throw new InsufficientSuppliesException("The item is not available.");
            }

            StoreSupplies[item]--;
        }
    }
}
