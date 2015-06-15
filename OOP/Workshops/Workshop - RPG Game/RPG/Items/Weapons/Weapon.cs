namespace RPG.Items.Weapons
{
    using Interfaces;

    public abstract class Weapon : Item, IDamageInflict
    {
        protected Weapon(Position position, int damage)
            : base(position)
        {
            this.Damage = damage;
        }

        public int Damage { get; private set; }
    }
}
