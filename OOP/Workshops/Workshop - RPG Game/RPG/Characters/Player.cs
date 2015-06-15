namespace RPG.Characters
{
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using Interfaces;
    using Items;
    using Items.Shields;
    using Items.Weapons;

    public class Player : Character, IPlayer
    {
        private const int DefaultPlayerXPosition = 0;
        private const int DefaultPlayerYPosition = 0;
        private const int DefaultPlayerHitPoints = 300;
        private const int DefaultPlayerDamage = 75;
        private const int DefaultPlayerArmor = 0;

        private readonly IList<ICollectible> inventory;

        public Player()
            : base(new Position(DefaultPlayerXPosition, DefaultPlayerYPosition), DefaultPlayerDamage, DefaultPlayerHitPoints, DefaultPlayerArmor)
        {
            this.inventory = new List<ICollectible>();
        }

        public override int Damage
        {
            get
            {
                int damage = base.Damage;

                damage += this.Inventory
                    .Where(i => i is Weapon)
                    .Cast<Weapon>()
                    .Select(i => i.Damage)
                    .Max();

                return damage;
            }
        }

        public override int Armor
        {
            get
            {
                int armor = this.Inventory.Where(a => a is Armor).Cast<Armor>().Select(a => a.HitPoints).Max();

                return armor;
            }
        }

        public override int HitPoints
        {
            set
            {
                if (value > DefaultPlayerHitPoints)
                {
                    value = DefaultPlayerHitPoints;
                }

                base.HitPoints = value;
            }
        }

        public IEnumerable<ICollectible> Inventory
        {
            get
            {
                return this.inventory;
            }
        }

        public int Score { get; set; }

        public void DrinkPotion()
        {
            var potion = this.Inventory.FirstOrDefault(i => i is HealthPotion) as HealthPotion;

            if (potion == null)
            {
                throw new MissingItemException("No health potions available in inventory.");
            }

            this.HitPoints += potion.HealthRestore;
            this.inventory.Remove(potion);
        }

        public void AddItemToInventory(ICollectible item)
        {
            this.inventory.Add(item);
        }
    }
}
