namespace RPG.Items.Weapons
{
    using Attributes;

    [Item]
    public class RegularSword : Weapon
    {
        private const int DefaultRegularSwordDamage = 75;

        public RegularSword(Position position)
            : base(position, DefaultRegularSwordDamage)
        {
        }
    }
}
