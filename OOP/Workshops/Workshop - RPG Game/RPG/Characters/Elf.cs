namespace RPG.Characters
{
    using Attributes;

    [Enemy]
    public class Elf : Character
    {
        public const int DefaultElfHitPoints = 175;
        public const int DefaultElfDamage = 75;
        public const int DefaultElfArmor = 15;

        public Elf(Position position)
            : base(position, DefaultElfDamage, DefaultElfHitPoints, DefaultElfArmor)
        {
        }
    }
}
