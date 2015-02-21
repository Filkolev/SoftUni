namespace TheSlum.GameObjects.Characters
{
    using System;
    using System.Linq;
    using Interfaces;
    using Items;

    class Healer : Character, IHeal
    {
        private const int DefaultHealthPoints = 75;
        private const int DefaultDefensePoints = 50;
        private const int DefaultRange = 6;

        private int healingPoints = 60;

        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, DefaultHealthPoints, DefaultDefensePoints, team, DefaultRange)
        {
        }

        public int HealingPoints
        {
            get
            {
                return this.healingPoints;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("healingPoints", "Healing points cannot be negative.");
                }

                this.healingPoints = value;
            }
        }

        public override Character GetTarget(System.Collections.Generic.IEnumerable<Character> targetsList)
        {
            Character target = targetsList
                .Where(x => x.IsAlive)
                .Where(x => x.Team == this.Team)
                .Where(x => x != this)
                .OrderBy(x => x.HealthPoints)
                .FirstOrDefault();

            return target;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }

        public override string ToString()
        {
            return string.Format("{0}, Healing: {1}", base.ToString(), this.HealingPoints);
        }
    }
}
