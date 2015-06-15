namespace RPG.Interfaces
{
    using Items;

    public interface ICollectible : IGameObject
    {
        ItemState State { get; set; }
    }
}
