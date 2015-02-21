namespace TheSlum.GameObjects.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Items;

    class Mage : Character, IAttack
    {
        private const int DefaultHealthPoints = 150;
        private const int DefaultDefensePoints = 50;
        private const int DefaultRange = 5;

        private int attackPoints = 300;

        public Mage(string id, int x, int y, Team team)
            : base(id, x, y, DefaultHealthPoints, DefaultDefensePoints, team, DefaultRange)
        {
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("attackPoints", "Attack points cannot be negative.");
                }

                this.attackPoints = value;
            }
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character target = targetsList
                .Where(x => x.IsAlive && x.Team != this.Team)
                .LastOrDefault();

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

        protected override void ApplyItemEffects(Item item)
        {
            base.ApplyItemEffects(item);
            this.AttackPoints += item.AttackEffect;
        }

        protected override void RemoveItemEffects(Item item)
        {
            base.RemoveItemEffects(item);
            this.AttackPoints -= item.AttackEffect;
        }

        public override string ToString()
        {
            return string.Format("{0}, Attack: {1}", base.ToString(), this.AttackPoints);
        }
    }
}
