namespace RPG.Interfaces
{
    public interface IPlayer : ICharacter, ICollect
    {
        int Score { get; set; }

        void DrinkPotion();
    }
}
