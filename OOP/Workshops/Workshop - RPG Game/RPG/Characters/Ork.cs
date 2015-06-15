namespace RPG.Characters
{
    using Attributes;

    [Enemy]
    public class Ork : Character
    {
        public const int DefaultOrkHitPoints = 90;
        public const int DefaultOrkDamage = 25;
        public const int DefaultOrkArmor = 10;

        public Ork(Position position)
            : base(position, DefaultOrkDamage, DefaultOrkHitPoints, DefaultOrkArmor)
        {
        }
    }
}
