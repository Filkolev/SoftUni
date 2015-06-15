namespace RPG.Engine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Attributes;
    using Interfaces;
    using Items;
    using Items.Shields;
    using Items.Weapons;

    public class GameEngine : IGameEngine
    {
        private readonly IList<IGameObject> entities;
        private readonly IRenderer renderer;
        private readonly IInputHandler inputHandler;
        private readonly IPlayer player;

        public GameEngine(IRenderer renderer, IInputHandler inputHandler, IPlayer player)
        {
            this.entities = MapInitializer.PopulateMap();
            this.renderer = renderer;
            this.inputHandler = inputHandler;
            this.player = player;
        }

        public bool IsRunning { get; private set; }

        public void Run()
        {
            this.IsRunning = true;
            this.ShowHelp();

            while (this.IsRunning)
            {
                int enemiesLeft = this.entities.Count(e => e is ICharacter);

                if (enemiesLeft == 0)
                {
                    this.renderer.WriteLine("Victory! We slew the evil hordes!");
                    break;
                }

                string command = this.inputHandler.ReadLine();

                try
                {
                    this.ProcessCommand(command);
                }
                catch (Exception ex)
                {
                    this.renderer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string command)
        {
            switch (command)
            {
                case "help":
                    this.ShowHelp();
                    break;
                case "left":
                    this.player.Position = new Position(this.player.Position.X - 1, this.player.Position.Y);
                    this.CheckForCollision();
                    break;
                case "right":
                    this.player.Position = new Position(this.player.Position.X + 1, this.player.Position.Y);
                    this.CheckForCollision();
                    break;
                case "up":
                    this.player.Position = new Position(this.player.Position.X, this.player.Position.Y - 1);
                    this.CheckForCollision();
                    break;
                case "down":
                    this.player.Position = new Position(this.player.Position.X, this.player.Position.Y + 1);
                    this.CheckForCollision();
                    break;
                case "status":
                    this.PrintStatus();
                    break;
                case "enemies":
                    this.ShowEnemyInfo();
                    break;
                case "clear":
                    this.ClearScreen();
                    break;
                case "map":
                    this.DisplayMap();
                    break;
                case "inventory":
                    this.ShowInventoryInfo();
                    break;
                case "heal":
                    this.DrinkHealthPotion();
                    break;
                case "surrender":
                    this.IsRunning = false;
                    this.renderer.WriteLine("Loser...");
                    break;
                default:
                    throw new ArgumentException("Unknown command.");
            }
        }

        private void ShowInventoryInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Player Inventory:");

            foreach (var collectible in this.player.Inventory)
            {
                if (collectible is HealthPotion)
                {
                    var item = collectible as HealthPotion;

                    sb.AppendFormat(
                        "{0} - Health Restore: {1}{2}",
                        item.GetType().Name,
                        item.HealthRestore,
                        Environment.NewLine);
                }
                else if (collectible is Weapon)
                {
                    var item = collectible as Weapon;

                    sb.AppendFormat(
                        "{0} - Damage: {1}{2}",
                        item.GetType().Name,
                        item.Damage,
                        Environment.NewLine);
                }
                else if (collectible is Armor)
                {
                    var item = collectible as Armor;
                    sb.AppendFormat(
                        "{0} - Hit Points: {1}{2}",
                        item.GetType().Name,
                        item.HitPoints,
                        Environment.NewLine);
                }
            }

            this.renderer.WriteLine(sb.ToString().Trim());
        }

        private void DrinkHealthPotion()
        {
            this.player.DrinkPotion();
            this.renderer.WriteLine("Player healed!");
        }

        private void CheckForCollision()
        {
            var collidingObject = this.entities
                .FirstOrDefault(e => e.Position.Equals(this.player.Position));

            var item = collidingObject as ICollectible;

            if (item != null)
            {
                this.player.AddItemToInventory(item);
                this.renderer.WriteLine("Added item to inventory: {0}", item.GetType().Name);
                item.State = ItemState.Collected;

                return;
            }

            var enemy = collidingObject as ICharacter;

            if (enemy != null)
            {
                this.EnterAttackPhase(enemy);
            }
        }

        private void EnterAttackPhase(ICharacter enemy)
        {
            if (enemy.HitPoints == 0)
            {
                return;
            }

            this.renderer.WriteLine(
                "Enemy encountered: {0} (damage: {1}, hit points: {2})",
                enemy.GetType().Name,
                enemy.Damage,
                enemy.HitPoints);

            while (enemy.HitPoints > 0)
            {
                this.renderer.WriteLine("Do you want to attack? (y/n)");

                string choice = this.inputHandler.ReadLine();

                while (choice != "n" & choice != "y")
                {
                    this.renderer.WriteLine("Invalid choice, please enter 'y' or 'n'.");
                    choice = this.inputHandler.ReadLine();
                }

                switch (choice)
                {
                    case "n":
                        this.renderer.WriteLine("Chicken!!! Y U no fight?!?");
                        return;
                    case "y":
                        this.PerformAttack(enemy);
                        break;
                }
            }
        }

        private void PerformAttack(ICharacter enemy)
        {
            this.player.Attack(enemy);

            if (enemy.HitPoints == 0)
            {
                this.entities.Remove(enemy);
                this.renderer.WriteLine("Enemy was defeated!");
                this.player.Score += 100;
                return;
            }

            enemy.Attack(this.player);
            this.renderer.WriteLine("Damage taken!");
            this.renderer.WriteLine("Player hit points: {0}", this.player.HitPoints);
            this.renderer.WriteLine("Enemy hit points: {0}", enemy.HitPoints);
        }

        private void ShowEnemyInfo()
        {
            var enemies = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass)
                .Where(t => t.CustomAttributes
                    .Any(a => a.AttributeType == typeof(EnemyAttribute)))
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var enemy in enemies)
            {
                var damage = enemy.GetFields().First(f => f.Name.EndsWith("Damage")).GetRawConstantValue();

                var hitPoints = enemy.GetFields().First(f => f.Name.EndsWith("HitPoints")).GetRawConstantValue();

                var armor = enemy.GetFields().First(f => f.Name.EndsWith("Armor")).GetRawConstantValue();

                sb.Append(enemy.Name);
                sb.AppendFormat(": Damage: {0}, Hit Points: {1}, Armor: {2}", damage, hitPoints, armor);
                sb.AppendLine();
            }

            this.renderer.WriteLine(sb.ToString().Trim());
        }

        private void ClearScreen()
        {
            this.renderer.Clear();
        }

        private void DisplayMap()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("P - Player, T - Treasure (armor or weapon), other - Enemy");

            for (int row = 0; row < Constants.MapHeight; row++)
            {
                for (int col = 0; col < Constants.MapWidth; col++)
                {
                    if (this.player.Position.X == col && this.player.Position.Y == row)
                    {
                        sb.Append('P');
                        continue;
                    }

                    IGameObject currentObject = this.entities
                        .FirstOrDefault(e => e.Position.X == col && e.Position.Y == row);

                    if (currentObject is ICollectible && (currentObject as ICollectible).State == ItemState.Available)
                    {
                        sb.Append('T');
                    }
                    else if (currentObject is ICharacter && (currentObject as ICharacter).HitPoints > 0)
                    {
                        sb.Append(currentObject.GetType().Name[0]);
                    }
                    else
                    {
                        sb.Append('.');
                    }
                }

                sb.AppendLine();
            }
            
            this.renderer.WriteLine(sb.ToString());
        }

        private void PrintStatus()
        {
            int enemiesLeft = this.entities.Count(e => e is ICharacter && ((ICharacter)e).HitPoints > 0);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine(string.Format(
                "Player Stats: Hit Points ({0}), Damage ({1}), Inventory: {2}", 
                this.player.HitPoints, 
                this.player.Damage,
                string.Join(", ", this.player.Inventory.Select(item => item.GetType().Name))));
            sb.Append("Enemies left: " + enemiesLeft);

            this.renderer.WriteLine(sb.ToString());
        }

        private void ShowHelp()
        {
            StreamReader reader = new StreamReader(@"../../HelpInfo.txt");

            string info = reader.ReadToEnd();

            this.renderer.WriteLine(info);
        }
    }
}
