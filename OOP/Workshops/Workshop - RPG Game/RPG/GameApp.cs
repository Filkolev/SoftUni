namespace RPG
{
    using Characters;
    using Engine;
    using Interfaces;
    using Items;
    using Items.Shields;
    using Items.Weapons;
    using UI;

    public class GameApp
    {
        public static void Main()
        {
            IRenderer renderer = new ConsoleRenderer();
            IInputHandler inputHandler = new ConsoleInputHandler();
            IPlayer player = new Player();
            SeedInitialPlayerInventory(player);

            IGameEngine engine = new GameEngine(renderer, inputHandler, player);

            engine.Run();
        }

        private static void SeedInitialPlayerInventory(IPlayer player)
        {
            Position defaultPosition = new Position(0, 0);

            ICollectible healthPotion = new HealthPotion(defaultPosition);
            healthPotion.State = ItemState.Collected;

            ICollectible shield = new RegularShield(defaultPosition);
            shield.State = ItemState.Collected;

            ICollectible sword = new RegularSword(defaultPosition);
            sword.State = ItemState.Collected;

            player.AddItemToInventory(healthPotion);
            player.AddItemToInventory(healthPotion);
            player.AddItemToInventory(shield);
            player.AddItemToInventory(sword);
        }
    }
}
