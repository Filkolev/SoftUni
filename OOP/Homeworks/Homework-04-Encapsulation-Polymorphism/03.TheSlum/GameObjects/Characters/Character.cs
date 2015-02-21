namespace TheSlum.GameObjects.Characters
{
    using System.Collections.Generic;
    using Items;

    public abstract class Character : GameObject
    {
        protected Character(string id, int x, int y, int healthPoints, int defensePoints, Team team, int range)
            : base(id)
        {
            this.HealthPoints = healthPoints;
            this.DefensePoints = defensePoints;
            this.Team = team;
            this.IsAlive = true;
            this.X = x;
            this.Y = y;
            this.Inventory = new List<Item>();
            this.Range = range;
        }

        public int HealthPoints { get; set; }

        public int DefensePoints { get; set; }

        public Team Team { get; private set; }

        public List<Item> Inventory { get; private set; }

        public int Range { get; set; }

        public bool IsAlive { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public abstract Character GetTarget(IEnumerable<Character> targetsList);

        public abstract void AddToInventory(Item item);

        public abstract void RemoveFromInventory(Item item);

        protected virtual void ApplyItemEffects(Item item)
        {
            this.HealthPoints += item.HealthEffect;
            this.DefensePoints += item.DefenseEffect;
        }

        protected virtual void RemoveItemEffects(Item item)
        {
            this.HealthPoints -= item.HealthEffect;
            this.DefensePoints -= item.DefenseEffect;
            if (this.HealthPoints < 0)
            {
                this.HealthPoints = 1;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Name: {0}, Team: {2}, Health: {1}, Defense: {3}",
                this.Id, 
                this.HealthPoints, 
                this.Team, 
                this.DefensePoints);
        }
    }
}
