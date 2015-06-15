namespace RPG.Items.Shields
{
    using Attributes;

    [Item]
    public class RegularShield : Armor
    {
        private const int DefaultRegularShieldHitPoints = 15;

        public RegularShield(Position position)
            : base(position, DefaultRegularShieldHitPoints)
        {
        }
    }
}
