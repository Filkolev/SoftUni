namespace RPG.Interfaces
{
    using System.Collections.Generic;

    public interface ICollect
    {
        IEnumerable<ICollectible> Inventory { get; }

        void AddItemToInventory(ICollectible item);
    }
}
