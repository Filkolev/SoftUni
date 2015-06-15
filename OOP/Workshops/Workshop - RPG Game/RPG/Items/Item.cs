namespace RPG.Items
{
    using Interfaces;

    public abstract class Item : ICollectible
    {
        protected Item(Position position)
        {
            this.Position = position;
            this.State = ItemState.Available;
        }

        public Position Position { get; set; }

        public ItemState State { get; set; }
    }
}
